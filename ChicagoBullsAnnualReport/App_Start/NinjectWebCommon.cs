using AutoMapper;
using ChicagoBullsAnnualReport.App_Start;
using ChicagoBullsAnnualReport.Controllers;
using ChicagoBullsAnnualReport.Core;
using ChicagoBullsAnnualReport.Mapper;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace ChicagoBullsAnnualReport.App_Start
{
    public class NinjectWebCommon
    {

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IReportHelper>().To<ReportHelper>();
            kernel.Bind<IFileHelper>().To<FileHelper>();
            kernel.Bind<IReportBuilder>().To<ReportBuilder>();
            kernel.Bind<IModelMapper>().To<ModelMapper>();
            kernel.Bind<AutoMapper.MapperConfiguration>().ToProvider<AutoMapperConfigProvider>().InSingletonScope();
            kernel.Bind<AutoMapper.IMapper>().ToMethod(context => context.Kernel.Get<MapperConfiguration>().CreateMapper());
        }
    }
}