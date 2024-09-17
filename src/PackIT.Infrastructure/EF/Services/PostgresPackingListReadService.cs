using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {

        private readonly DbSet<PackingListReadModel> _packingList;

        public PostgresPackingListReadService(ReadDbContext context)
            => _packingList = context.PackingLists;


        public Task<bool> ExistsByNameAsync(string Name)
            => _packingList.AnyAsync(pl => pl.Name == Name);

        public Task<IEnumerable<PackingListDto>> SearchAsync(string searchPhrase)
        {
            throw new NotImplementedException();
        }
    }
}
