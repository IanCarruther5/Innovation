using innovation.Enums;

namespace innovation.Model
{
    public class OrderRule
    {
        public OrderRule()
        {
        }
        public Inputs Input { get; set; } = new Inputs();
        public OrderStatus OrderStatus { get; set; }
    }
}

