using Autofac.Integration.WebApi;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using CleanArchitecture.DataAccess.Persistence;
using CleanArchitecture.DataAccess.Core.Interfaces;
using System.Web.Http;

namespace CleanArchitecture.MVC.App_Start
{
    public class ConteinerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
//---------------------------------------------------------------------------------------------------------------------------
            //Register UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //Register DbContext
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();            
//---------------------------------------------------------------------------------------------------------------------------
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void RegisterContainerApi()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
//---------------------------------------------------------------------------------------------------------------------------

            //Register UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //Register DbContext
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();

//---------------------------------------------------------------------------------------------------------------------------

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}