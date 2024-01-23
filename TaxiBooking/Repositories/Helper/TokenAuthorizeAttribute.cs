using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TaxiBooking.Repositories.Helper
{
    public class TokenAuthorizeAttribute : AuthorizeAttribute
    {
      
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Retrieve the token from the Authorization header
            string authorizationHeader = httpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                // Extract the token from the header
                string token = authorizationHeader.Substring("Bearer ".Length);

                // Now you have the token, and you can perform any necessary validation or processing
                if (!string.IsNullOrEmpty(token))
                {
                    // Token is valid, authorize the request
                    return true;
                }
            }
            else
            {
                HttpCookie token = httpContext.Request.Cookies["Token"];

                if (token != null)
                {
                    return true;

                }
                return false;

            }

            // Token is missing or invalid, deny authorization
            return false;
        }
    }
}