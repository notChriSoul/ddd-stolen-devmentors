using PackIT.Domain.Consts;
using PackIT.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PackIT.Application.Commands
{
    // why not value object?
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender, 
        LocalizationWriteModel Localization ) : ICommand;

    // WHY NOT VALUE OBJECT AGAIN
    public record LocalizationWriteModel(string City, string Country);
}
