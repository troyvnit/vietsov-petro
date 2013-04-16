using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using VietSovPetro.CommandProcessor.Commands;
using VietSovPetro.CommandProcessor.Commands.ICommands;
using VietSovPetro.CommandProcessor.Dispatcher;
using VietSovPetro.Data.Infrastructure;
using VietSovPetro.Data.Repositories;
using VietSovPetro.Domain;
using System.Web.Http;
using VietSovPetro.BO.Mappers;
namespace VietSovPetro.BO
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerHttpRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(ArticleCategoryRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerHttpRequest();
            var services = Assembly.Load("VietSovPetro.Domain");
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerHttpRequest();
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
