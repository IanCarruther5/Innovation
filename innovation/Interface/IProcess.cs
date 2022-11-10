using innovation.Enums;
using innovation.Model;

namespace innovation.Interface
{
    public interface IProcess
    {
        OrderStatus ProcessOrder(Inputs input);
    }
}

