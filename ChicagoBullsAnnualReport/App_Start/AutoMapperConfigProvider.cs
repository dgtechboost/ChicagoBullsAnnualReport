using System;
using AutoMapper;
using ChicagoBullsAnnualReport.Mapper;
using Ninject.Activation;

namespace ChicagoBullsAnnualReport.App_Start
{
    public class AutoMapperConfigProvider : IProvider
    {
        public Type Type { get; }

        public object Create(IContext context)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ReportProfile());  
            });

            return config;
        }
    }
}