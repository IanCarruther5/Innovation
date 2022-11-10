using innovation.Enums;
using innovation.Interface;
using innovation.Model;

namespace innovation.Service
{
    public class Process:IProcess
    {
        private readonly IRules _rules;

        public Process(IRules rules)
        {
            _rules = rules;
        }

        public OrderStatus ProcessOrder(Inputs input)
        {
            OrderRule? o = _rules.ReadRules().FirstOrDefault(x =>
            (x.Input.IsLargeOrder == input.IsLargeOrder || x.Input.IsLargeOrder == null) &&
            (x.Input.IsNewCustomer == input.IsNewCustomer || x.Input.IsNewCustomer == null) &&
            (x.Input.IsRushOrder == input.IsRushOrder || x.Input.IsRushOrder == null) &&
            (x.Input.OrderType == input.OrderType || x.Input.OrderType == null));

            return o?.OrderStatus??OrderStatus.Confirmed;
        }
    }
}

