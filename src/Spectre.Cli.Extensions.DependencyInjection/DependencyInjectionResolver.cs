using System;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Cli;

namespace Spectre.Cli.Extensions.DependencyInjection
{
    internal class DependencyInjectionResolver : ITypeResolver
    {
        internal DependencyInjectionResolver(IServiceCollection services)
        {
            Services = services;
        }
        internal IServiceCollection Services {get;set;}

        public object Resolve(Type type)
        {
            return (Services.BuildServiceProvider()).GetService(type) ?? Activator.CreateInstance(type);
        }
    }
}