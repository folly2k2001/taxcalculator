﻿using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TaxCalculationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("TaxCalculationDbConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICalculatedTaxRepository, CalculatedTaxRepository>();
            services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();
            services.AddScoped<ITaxCalculationTypeRepository, TaxCalculationTypeRepository>();
            services.AddScoped<IPostalCode_TaxCalculationTypeRepository, PostalCode_TaxCalculationTypeRepository>();

            return services;
        }
    }
}
