using Microsoft.EntityFrameworkCore;
using NewsApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ArticleDb>(options => options.UseInMemoryDatabase("ArticleDatabase"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

RouteGroupBuilder articles = app.MapGroup("/articles");

articles.MapGet("/", GetAllArticlesAsync);
articles.MapGet("/{id}", GetArticleByIdAsync);
articles.MapGet("/published", GetAllPublishedArticlesAsync);
articles.MapPost("/", CreateArticleAsync);
articles.MapPut("/{id}", UpdateArticleByIdAsync);
articles.MapDelete("/{id}", DeleteArticleByIdAsync);

app.Run();


static async Task<IResult> GetAllArticlesAsync(ArticleDb db)
{
    return TypedResults.Ok(await db.Articles.ToArrayAsync());
}
static async Task<IResult> GetArticleByIdAsync(int id, ArticleDb db)
{
    return await db.Articles.FindAsync(id) is Article article ? TypedResults.Ok(article) : TypedResults.NotFound();
}
static async Task<IResult> GetAllPublishedArticlesAsync(ArticleDb db)
{
    return TypedResults.Ok(await db.Articles.Where(x => x.State == State.Published).ToArrayAsync());
}

static async Task<IResult> CreateArticleAsync(Article article, ArticleDb db)
{
    db.Articles.Add(article);

    await db.SaveChangesAsync();
    return TypedResults.Created($"/{article.Id}", article);
}

static async Task<IResult> UpdateArticleByIdAsync(int id, Article inputArticle, ArticleDb db)
{
    var existingArticle = await db.Articles.FindAsync(id);

    if (existingArticle is null) return TypedResults.NotFound();

    existingArticle.Title = inputArticle.Title;
    existingArticle.Content = inputArticle.Content;
    existingArticle.State = inputArticle.State;
    existingArticle.Author = inputArticle.Author;
    existingArticle.PublishedOn = inputArticle.PublishedOn;

    await db.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteArticleByIdAsync(int id, ArticleDb db)
{
    var article = await db.Articles.FindAsync(id);
    if (article is not null)
    {
        db.Articles.Remove(article);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    return TypedResults.NotFound();
}