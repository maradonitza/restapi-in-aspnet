using BookstoreApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BookstoreApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            AutoMapperProfile.Run();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
