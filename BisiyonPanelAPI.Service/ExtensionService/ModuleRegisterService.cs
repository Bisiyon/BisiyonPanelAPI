using Autofac;
using BisiyonPanelAPI.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BisiyonPanelAPI.Service
{
    public class ModuleRegisterService : Module
    {
        private readonly IConfiguration _configuration;

        public ModuleRegisterService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Örnek: JwtTokenGenerator servisi (interface ve class daha önce tanımlanmalı)
            builder.RegisterType<JwtTokenGenerator>()
                   .As<IJwtTokenGenerator>()
                   .SingleInstance();

            builder.RegisterType<TenantDbContextFactory>()
                   .As<ITenantDbContextFactory>()
                   .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RepositoryBase<>))
                   .As(typeof(IRepositoryBase<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                  .As<IUnitOfWork>()
                  .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ServiceBase<>))
                   .As(typeof(IServiceBase<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                   .As<IUserService>()
                   .InstancePerLifetimeScope();

        }
    }
}