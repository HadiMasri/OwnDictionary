using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OwnDictionary.Application.Dxos;
using OwnDictionary.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.Extentions
{
    public static class ApplicationExtentions
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(ApplicationExtentions)));
            services.AddScoped<ITermDxos, TermDxos>();
            services.AddScoped<ILanguageDxos, LanguageDxos>();

            AssemblyScanner.FindValidatorsInAssemblyContaining<CommandBase<IValidator>>().ForEach(pair =>
            {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
                services.Add(ServiceDescriptor.Transient(pair.ValidatorType, pair.ValidatorType));
            });
        }
    }
}
