using Autofac;
using Business.TrueMoney.Core;
using Business.TrueMoney.Core.Interface;
using DataAccess.Entities.Context;
using DataAccess.Entities.Context.Interface;
using DataAccess.Repository.TrueMoney;
using DataAccess.Repository.TrueMoney.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMVC.Infrastructure
{
    public class DependencyInjection
    {
        public ContainerBuilder OnConfigure(ContainerBuilder builder)
        {
            //Context Injection
            builder.RegisterType<CoreTemplateEntities>().As<ICoreTemplateEntities>().InstancePerLifetimeScope();

            //Generic Repository Injection
            builder.RegisterGeneric(typeof(CoreTemplateRepository<>)).As(typeof(ICoreTemplateRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<ServerGuideServices>().As<IServerGuideServices>().InstancePerLifetimeScope();

            return builder;
        }
    }
}