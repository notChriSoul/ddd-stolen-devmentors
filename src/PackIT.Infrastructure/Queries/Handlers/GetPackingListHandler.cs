using PackIT.Application.DTO;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {

        private readonly IPackingListRepository _repository;

        public GetPackingListHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task<PackingListDto> HandleAsync(GetPackingList query)
        {
            var packingList = await _repository.GetAsync(query.Id);
            return packingList?.AsDto();   

        }
    }
}
