using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class PackingListAlreadyExistsException : PackITException
    {
        public string Name { get; }

        public PackingListAlreadyExistsException(string name) : base($"Packing list with name '{name}' already exists.")
        {
            Name = name;        
        }

    }
}
