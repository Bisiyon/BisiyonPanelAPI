using Autofac;
using BisiyonPanelAPI.Domain;
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
                     #region AppServices

                     builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

                     builder.RegisterType<AidatService>().As<IAidatService>().InstancePerLifetimeScope();
                     builder.RegisterType<AidatGrupService>().As<IAidatGrupService>().InstancePerLifetimeScope();
                     builder.RegisterType<AracService>().As<IAracService>().InstancePerLifetimeScope();
                     builder.RegisterType<BlokService>().As<IBlokService>().InstancePerLifetimeScope();
                     builder.RegisterType<IlService>().As<IIlService>().InstancePerLifetimeScope();
                     builder.RegisterType<IlceService>().As<IIlceService>().InstancePerLifetimeScope();
                     builder.RegisterType<MeskenService>().As<IMeskenService>().InstancePerLifetimeScope();
                     builder.RegisterType<MeskenTipiService>().As<IMeskenTipiService>().InstancePerLifetimeScope();
                     builder.RegisterType<UyeService>().As<IUyeService>().InstancePerLifetimeScope();
                     builder.RegisterType<UyeDurumTipService>().As<IUyeDurumTipService>().InstancePerLifetimeScope();
                     builder.RegisterType<UyeHareketService>().As<IUyeHareketService>().InstancePerLifetimeScope();
                     builder.RegisterType<DemirbasService>().As<IDemirbasService>().InstancePerLifetimeScope();
                     builder.RegisterType<PersonelService>().As<IPersonelService>().InstancePerLifetimeScope();
                     builder.RegisterType<PersonelTipService>().As<IPersonelTipService>().InstancePerLifetimeScope();
                     builder.RegisterType<AracHareketService>().As<IAracHareketService>().InstancePerLifetimeScope();
                     builder.RegisterType<PersonelGorevService>().As<IPersonelGorevService>().InstancePerLifetimeScope();
                     builder.RegisterType<MeskenUyeService>().As<IMeskenUyeService>().InstancePerLifetimeScope();




                     #endregion

                     #region InfrastructureService

                     builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>)).InstancePerLifetimeScope();
                     builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
                     builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>)).InstancePerLifetimeScope();
                     builder.RegisterType<TenantDbContextFactory>().As<ITenantDbContextFactory>().InstancePerLifetimeScope();
                     builder.RegisterType<JwtTokenGenerator>().As<IJwtTokenGenerator>().SingleInstance();
                     builder.RegisterType<TenantServiceScopeFactory>().As<ITenantServiceScopeFactory>().InstancePerLifetimeScope();
                     builder.RegisterType<ConfigurationService>().As<IConfigurationService>().InstancePerLifetimeScope();

                     #endregion
              }
       }
}