
using System.Text.RegularExpressions;

namespace RoutingCoreMVC.Extensions
{
    public class AlphaNumericConstraint: IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(httpContext == null || route == null || routeKey == null || values == null)
            throw new ArgumentNullException();

            if (values.TryGetValue(routeKey, out object? routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue);

                if(Regex.IsMatch(parameterValueString ?? string.Empty, "^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9]+$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
