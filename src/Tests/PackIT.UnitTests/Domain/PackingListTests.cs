using PackIT.Domain.Entities;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using Shouldly;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Events;
using System.Reflection.Emit;

namespace PackIT.UnitTests.Domain
{
    public class PackingListTests
    {
        //Arrange

        private readonly IPackingListFactory _factory;

        public PackingListTests()
        {
            _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
        }

        private PackingList GetPackingList()
        {

            var packingList = _factory.Create(Guid.NewGuid(), "MyList", Localization.Create("Warsaw, Poland"));
            packingList.ClearEvents();
            return packingList; 

        }



        [Fact]
        public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_An_Item_With_The_Same_Name()
        {
            // Arrange
            var packingList = GetPackingList();
            packingList.AddItem(new PackingItem("Item 1", 1));

            // Act

            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingItemAlreadyExistsException>();

        }

        [Fact]
        public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
        {


            var packingList = GetPackingList();
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

            exception.ShouldBeNull();
            packingList.Events.Count().ShouldBe(1);


            var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

            @event.ShouldNotBeNull();

            ((PackingItemAdded)@event).PackingItem.Name.ShouldBe("Item 1");

        }




    }
}
