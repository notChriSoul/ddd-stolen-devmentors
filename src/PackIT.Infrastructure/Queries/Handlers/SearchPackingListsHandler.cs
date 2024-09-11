using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries.Handlers
{
    public class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {

        // private readonly PackItDbContext
        public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
            throw new NotImplementedException();
        }
    }
}
