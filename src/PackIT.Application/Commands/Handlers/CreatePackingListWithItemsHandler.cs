﻿using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {

        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListReadService _readService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory, IPackingListReadService readService)
        {
            _repository = repository;
            _factory = factory;
            _readService = readService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {

            var (id, name, days, gender, localization) = command; // ?

            if(await _readService.ExistsByNameAsync(name))
             {
                throw new PackingListAlreadyExistsException(name);
            }

        }
    }
}
