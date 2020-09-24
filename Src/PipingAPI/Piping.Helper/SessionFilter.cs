using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Piping.Helper
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string id = context.HttpContext.Session.GetString("ID");
            if (string.IsNullOrWhiteSpace(id))
            {
                //context.Result = new RedirectToRouteResult(new RouteValueDictionary {{ "Controller", "" },
                //                      { "Action", "" } });
            }
            base.OnActionExecuting(context);
        }
    }
}
