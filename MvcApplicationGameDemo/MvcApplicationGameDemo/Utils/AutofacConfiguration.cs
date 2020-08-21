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

namespace MvcApplicationGameDemo.Utils
{
    public static class AutofacConfiguration
    {
        public static void ConfigurateAutofac()
        {
            // 1. Builder
            // 2. Reg all controllers in assembly
            // 3. Reg types
            // 4. Build container

            // 1. Builder
            var builder = new ContainerBuilder();
            // 2. Reg all controllers in assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // 3. Reg types
            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<GameServices>().As<IGameServices>();

            //Reg Mapper
            var mapperConfig = new MapperConfiguration(x=> x.AddProfile(new MapperConfig()));
            builder.RegisterInstance<IMapper>(mapperConfig.CreateMapper());
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}