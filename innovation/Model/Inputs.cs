using innovation.Enums;

namespace innovation.Model
{
    public class Inputs
    {
        public Inputs()
        {
        }
        public bool? IsRushOrder { get; set; }
        public OrderType? OrderType { get; set; }
        public bool? IsNewCustomer { get; set; }
        public bool? IsLargeOrder { get; set; }
    }
}

