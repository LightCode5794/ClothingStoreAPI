﻿using ClothingStore.Domain.Common;
using ClothingStore.Domain.Common.Interfaces;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace ClothingStore.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
                
        }
    }
}
