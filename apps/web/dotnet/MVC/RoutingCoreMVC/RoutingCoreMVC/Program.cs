using RoutingCoreMVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Method 1: Configuring the Custom Route Constraint Service using the AddRouting Method
builder.Services.AddRouting(options =>
{
    // This lambda is configuring the options for routing services that are added to the application's service container.
    options.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
    // Adds a new entry to the ConstraintMap dictionary with the key "alphanumeric".
    // "alphanumeric" is the name that you will use in your route definitions to apply this constraint.
    // typeof(AlphaNumericConstraint) specifies the type of the custom constraint that will handle the logic when this key is used in route definitions.
    // AlphaNumericConstraint is a custom class implementing IRouteConstraint, which enforces that a route parameter meets specific conditions (being alphanumeric in this case).
});
/*
// Method 2: Configuring the Custom Route Constraint Service using the Configure Method
builder.Services.Configure<RouteOptions>(routeOptions =>
{
    // This lambda function is used to configure an instance of RouteOptions,
    // which holds settings that direct how routing behaves in your application.

    // Adds a new entry to the ConstraintMap dictionary within the RouteOptions.
    routeOptions.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
    // "alphanumeric" is a string key that represents this particular constraint in route definitions.
    // typeof(AlphaNumericConstraint) points to the custom route constraint class that implements IRouteConstraint.
    // The AlphaNumericConstraint class defines the logic to check if a route parameter is alphanumeric.
});
*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

/* // Replaced with more clear default and pattern.
 app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
*/

app.MapControllerRoute(
   name: "default",
   pattern: "{controller}/{action}/{id:int?}",
   defaults: new { controller = "Home", action = "Index" });

/* Custom constraint in conventional routing
app.MapControllerRoute(
   name: "CustomRouting",
   pattern: "{controller}/{action}/{id:alphanumeric?}",
   defaults: new { controller = "Home", action = "Index"});
*/
/*
app.MapControllerRoute(
    name: "StudentAll",
    pattern: "Student/All",
    defaults: new { controller = "Student", action = "Index"});

app.MapControllerRoute(
    name: "StudentIndex",
    pattern: "StudentDetails/{ID}",
    defaults: new { controller = "Student", action = "Details" });
*/
// app.MapControllers();


app.Run();
