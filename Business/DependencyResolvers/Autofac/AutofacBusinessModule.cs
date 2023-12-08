using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterType<EfCoreStockType>().As<IStockTypeDal>();
            builder.RegisterType<StockTypeManager>().As<IStockTypeService>();

            builder.RegisterType<EfCoreStockUnitDal>().As<IStockUnitDal>();
            builder.RegisterType<StockUnitManager>().As<IStockUnitService>();
            
            builder.RegisterType<EfCoreStockDal>().As<IStockDal>();
            builder.RegisterType<StockManager>().As<IStockService>();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
