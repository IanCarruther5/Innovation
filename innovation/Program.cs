using innovation.Enums;
using innovation.Model;
using innovation.Service;

//This would be handled by DI and app settings
Process? process = new(new Rules("rules.json"));
Converter converter = new Converter();

Console.WriteLine("Innovation Order System");

bool run = true;
while (run)
{

    Inputs? input = new();

    Console.WriteLine("\nIs Large Order?  Y/N");
    input.IsLargeOrder = converter.YNToBool(Console.ReadKey().Key.ToString());

    Console.WriteLine("\nIs New Customer Order?  Y/N");
    input.IsNewCustomer = converter.YNToBool(Console.ReadKey().Key.ToString());

    Console.WriteLine("\nIs Rush Order?  Y/N");
    input.IsRushOrder = converter.YNToBool(Console.ReadKey().Key.ToString());

    Console.WriteLine("\nOrder Type?  H: Hire / R: Repair");
    input.OrderType = converter.ToOrderType(Console.ReadKey().Key.ToString());

    OrderStatus output = process.ProcessOrder(input);

    Console.WriteLine($"\n{output}");

    Console.WriteLine("Enter Another order?  Y/N");
    run = converter.YNToBool(Console.ReadKey().Key.ToString());
}
Console.WriteLine("\nExit System");


