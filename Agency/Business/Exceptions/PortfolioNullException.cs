﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class PortfolioNullException : Exception
    {
        public string PropertyName { get; set; }
        public PortfolioNullException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
