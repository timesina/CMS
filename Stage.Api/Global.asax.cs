using Autofac;
using Autofac.Integration.WebApi;
using Infrastructure;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Stage.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacInit();
        }

        /// <summary>
        /// 注册Autofac
        /// </summary>
        public void AutofacInit()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            //                        .Where(t => t.GetCustomAttribute<DependencyRegisterAttribute>() != null)
            //                        .AsImplementedInterfaces()
            //                        .InstancePerRequest();

            var agent = Assembly.Load("Infrastructure");
            builder.RegisterAssemblyTypes(agent, agent)
              .Where(t => t.Name.EndsWith("Reposity"))
              .AsImplementedInterfaces();

            //注册Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}
