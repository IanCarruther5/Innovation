using System;
using innovation.Enums;

namespace innovation.Interface
{
    public interface IConverter
    {
        public bool YNToBool(string input);
        public OrderType? ToOrderType(string input);
    }
}

