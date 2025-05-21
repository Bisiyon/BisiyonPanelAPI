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

            // Örnek: DaireService'i register et (diğer servisler benzer)
            // builder.RegisterType<DaireService>()
            //        .AsSelf()
            //        .InstancePerLifetimeScope();

            // Başka servisleri buraya ekle
        }
    }
}