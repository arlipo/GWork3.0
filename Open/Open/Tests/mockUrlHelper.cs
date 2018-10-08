using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
namespace Open.Tests
{
    internal class mockUrlHelper: IUrlHelper
    {
        public string ActionName;
        public string ControllerName;
        public string Values;
        public string ProtocolScheme;

        public string Action(UrlActionContext actionContext) {
            ActionName = actionContext.Action;
            ControllerName = actionContext.Controller;
            ProtocolScheme = actionContext.Protocol;
            Values = actionContext.Values.ToString();
            return ActionName;
        }
        public string Content(string contentPath) {
            throw new NotImplementedException();
        }
        public bool IsLocalUrl(string url) {
            throw new NotImplementedException();
        }
        public string RouteUrl(UrlRouteContext routeContext) {
            throw new NotImplementedException();
        }
        public string Link(string routeName, object values) {
            throw new NotImplementedException();
        }
        public ActionContext ActionContext { get; private set; }
    }
}
