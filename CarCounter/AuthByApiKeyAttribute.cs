using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CarCounter
{
    public class AuthByApiKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (IsAuthorized(filterContext))
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Response = filterContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    new { Success = false, Message = "Your API Key is incorrect." },
                    filterContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            }

        }

        public bool IsAuthorized(HttpActionContext filterContext)
        {
            string[] apikeys = ConfigurationManager.AppSettings["APIKeys"].Split(',');
            if (filterContext.Request.Headers.Authorization != null)
            {
                string apiKeyFromPost = filterContext.Request.Headers.Authorization.ToString();
                return apikeys.Contains(apiKeyFromPost);
            }
            return false;
        }


    }
}