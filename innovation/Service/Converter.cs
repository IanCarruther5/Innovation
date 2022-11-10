using innovation.Enums;
using innovation.Interface;

namespace innovation.Service
{
    public class Converter:IConverter
    {
        public Converter()
        {
        }

        public OrderType? ToOrderType(string input)
        {
            return input.ToLower() switch
            {
                "h" => OrderType.Hire,
                "r" => OrderType.Repair ,
                _ => null,
            };
        }

        public bool YNToBool(string input)
        {
            return input.ToLower() switch
            {
                "y" => true,
                "n" => false,
                _ => false,
            };
        }
    }
}

