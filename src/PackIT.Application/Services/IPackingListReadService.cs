using PackIT.Application.DTO;
using PackIT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Services
{
    public interface IPackingListReadService
    {
        Task<IEnumerable<PackingListDto>> SearchAsync(string searchPhrase);
        Task<bool> ExistsByNameAsync(string Name); // why not in the domain
    }
}
