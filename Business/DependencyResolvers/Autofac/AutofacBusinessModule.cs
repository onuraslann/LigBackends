using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlayerManager>().As<IPlayerService>().SingleInstance();
            builder.RegisterType<EfPlayerDal>().As<IPlayerDal>().SingleInstance();
            builder.RegisterType<LeagueManager>().As<ILeagueService>().SingleInstance();
            builder.RegisterType<EfLeagueDal>().As<ILeagueDal>().SingleInstance();
            builder.RegisterType<FixtureManager>().As<IFixtureService>().SingleInstance();
            builder.RegisterType<EfFixtureDal>().As<IFixtureDal>().SingleInstance();
            builder.RegisterType<TeamManager>().As<ITeamService>().SingleInstance();
            builder.RegisterType<EfTeamDal>().As<ITeamDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }

    }
}
