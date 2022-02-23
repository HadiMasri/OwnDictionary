﻿using MediatR;
using OwnDictionary.Models.Entities;
using OwnDictionary.Repositories.IRepositories;
using OwnDictionary.Repositories.Repositories;
using OwnDictionary.Repositories.UnitOfWork;

namespace OwnDictionary.API.Extentions
{
    public static class IoCExtentions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            //services.AddTransient<IMediator, Mediator>();
            services.AddTransient<IRepository<Term>, Repository<Term>>();
            //services.AddTransient<ITermRepository, TermRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
