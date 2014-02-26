using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using ServiceLayer;

namespace TheService
{
    public class Global : HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e) {}

        protected void Application_BeginRequest(object sender, EventArgs e) {}

        protected void Application_End(object sender, EventArgs e) {}

        protected void Application_Error(object sender, EventArgs e) {}

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("", new WebServiceHostFactory(), typeof(CineRestService)));
        }

        protected void Session_End(object sender, EventArgs e) {}

        protected void Session_Start(object sender, EventArgs e) {}
    }
}