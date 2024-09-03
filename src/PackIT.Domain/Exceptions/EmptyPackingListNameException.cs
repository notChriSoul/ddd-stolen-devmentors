﻿using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListNameException : PackITException
    {
        public EmptyPackingListNameException() 
            : base("packing list name cannot be empty") 
        {

        }

    }
}
