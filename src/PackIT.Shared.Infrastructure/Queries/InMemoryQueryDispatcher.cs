﻿using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstractions.Queries;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Queries
{
    internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {

        private readonly IServiceProvider _serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
            =>  _serviceProvider = serviceProvider;
        
        
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        { 
            using var scope = _serviceProvider.CreateScope();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

            // bruh
            return await (Task<TResult>)handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?
                .Invoke(handler, new[] { query });
                ;
        }
    }
}
