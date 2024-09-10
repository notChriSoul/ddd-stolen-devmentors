using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace PackIT.Domain.Factories
{
    public sealed class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemsPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
            =>  _policies = policies;
        

        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
            => new(id, name, localization);


        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
            Temperature temperature, Localization localization)
        {
            // specificaion of packing list?
            var data  = new PolicyData(days, gender, temperature, localization);
            // searching which policies are apllicable to this packing list
            var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

            // there may be many items that are applicable, so we select many
            var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
            // we create a list
            var packingList = Create(id, name, localization);
            // and add  those selected previously to our packing list
            packingList.AddItems(items);

            return packingList;
        }
    }
}
