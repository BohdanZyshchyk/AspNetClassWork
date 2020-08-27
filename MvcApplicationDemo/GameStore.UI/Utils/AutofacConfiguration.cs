using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GameStore.BLL.Services;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL;
using GameStore.DAL.Repository.Abstraction;
using GameStore.DAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Utils
{
    public static class AutofacConfiguration
    {
        public static void ConfigurateAutofac()
        {
            // 1. Builder
            // 2. Register all controllers in assembly
            // 3. Register types
            // 4. Resolve -> build container
            // 5. start this method

            // 1.
            var builder = new ContainerBuilder();
            // 2.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //3.
            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<GameService>().As<IGameService>();
            builder.RegisterType<DeveloperService>().As<IDeveloperService>();

            // Register Mapper
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MapperConfig()));
            builder.RegisterInstance<IMapper>(mapperConfig.CreateMapper());
            
            // 4. 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
// new GamesController(new GameService(new EFRepository(new ApplicationContext())))