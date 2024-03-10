using System.Reflection;
using Autofac;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;
using BurakSekmen.Repository.Context;
using BurakSekmen.Repository.Repositories;
using BurakSekmen.Repository.UnitOfWorks;
using BurakSekmen.Service.Mapping;
using BurakSekmen.Service.Services;
using Module = Autofac.Module;

namespace BurakSekmen.API.Modules
{
    public class RepoServiceModul:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorks>().As<IUnitOfWorks>();

            var ApiAssembly = Assembly.GetExecutingAssembly();

            var RepositoryAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            var ServiceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(ApiAssembly, RepositoryAssembly, ServiceAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ApiAssembly, RepositoryAssembly, ServiceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();




        }
    }
}
