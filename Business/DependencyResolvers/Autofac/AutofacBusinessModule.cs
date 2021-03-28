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
    public class AutofacBusinessModule : Module
    {
        //biz projeyi çalıştırdığımız anda bu load metodu çalışacak.
        protected override void Load(ContainerBuilder builder)
        {
            //resigterType services.addsingleton yapısına karşılık geliyor.
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            // birisi IProductService isterse ona productManager instance ver.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            //constructorda verip geç. 100 tane IproductService olsun yine de newlemene gerek yok. Autofac bunu senin yerine yapıyor.
            
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }


    }
}
