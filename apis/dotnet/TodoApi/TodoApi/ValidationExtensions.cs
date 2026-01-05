using System.ComponentModel.DataAnnotations;

namespace TodoApi.Extensions
{
    public static class ValidationExtensions
    {
        public static IResult? ValidateModel<T>(this T model)
        {
            var context = new ValidationContext(model!);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(model!, context, results, true))
            {
                return Results.BadRequest(new
                {
                    errors = results.Select(r => r.ErrorMessage)
                });
            }

            return null;
        }
    }

}
