using System;
using Microsoft.Extensions.DependencyInjection;

namespace Spectre.Cli.Extensions.DependencyInjection
{
    public class DependencyInjectionRegistrar : ITypeRegistrar
    {
        private readonly IServiceCollection _services;

        public DependencyInjectionRegistrar(IServiceCollection services)
        {
            _services = services;
        }
        public ITypeResolver Build()
        {
            return new DependencyInjectionResolver(_services);
        }

        public void Register(Type service, Type implementation)
        {
            _services.AddSingleton(service, implementation);
        }

        public void RegisterInstance(Type service, object implementation)
        {
            _services.AddSingleton(service, implementation);
        }
    }
}
