﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Repositories;
using Anntgc00492University.Service;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(anntgc00492University.Web.App_Start.Startup))]

namespace anntgc00492University.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
            ConfigureAuth(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<Anntgc00492UniversityDbContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(StudentRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(StudentService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
