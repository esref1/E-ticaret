using AOP.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess;
using FluentValidation;

namespace Business.DependencyAutofac
{
    public class AutoFacModule : Module
    {
        // Reflection Nedir ?
        // Programın derleme aşamasındaki Bütün Metotların ve Class'ların Hakkında bilgi almamıza olanak sağlayan bir kütüphanedir. Microsoft'un kendi dahili kütüphanesidir.

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EticaretContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<CategoriesService>().As<ICategoriesService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<OrdersRelationService>().As<IOrdersRelationService>();
            builder.RegisterType<ProductsService>().As<IProductsService>();
            builder.RegisterType<TemporaryBasketService>().As<ITemporaryBasketService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).InstancePerLifetimeScope();

            // Kullanacağımız Fluent Class'larını türetmemizi sağlayan yapı
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            .AsImplementedInterfaces();
        }

    }
}
