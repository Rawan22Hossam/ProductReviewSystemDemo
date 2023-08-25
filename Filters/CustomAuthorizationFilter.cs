using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace ProductReviewSystemDemo.Filters
{
    public class CustomAuthorizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Perform authorization logic here
            if (!IsAuthorized(actionContext))
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }
        private bool IsAuthorized(HttpActionContext actionContext)
        {
            // Implement your authorization logic based on your requirements
            // For example, you can check if the user has a valid JWT token or if they have certain roles/permissions

            // Return true if authorized, false otherwise
            return true;
        }

        private void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            // Handle unauthorized access
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }


}

