using innovation.Enums;
using innovation.Interface;
using innovation.Model;
using innovation.Service;
using Moq;

namespace innovation_xunit
{
    public class UnitTest
    {
        [Theory]
        //Large Repair New customers
        [InlineData(false, OrderType.Repair, true, true, OrderStatus.Closed)]
        [InlineData(true, OrderType.Repair, true, true, OrderStatus.Closed)]

        //Large Rush Hire orders
        [InlineData(true, OrderType.Hire, true, true, OrderStatus.Closed)]
        [InlineData(true, OrderType.Hire, false, true, OrderStatus.Closed)]

        //Large Repair
        [InlineData(false, OrderType.Repair, false, true, OrderStatus.AuthorisationRequired)]
        [InlineData(true, OrderType.Repair, false, true, OrderStatus.AuthorisationRequired)]

        //New customer rush orders
        [InlineData(true, OrderType.Repair, true, false, OrderStatus.AuthorisationRequired)]
        [InlineData(true, OrderType.Hire, true, false, OrderStatus.AuthorisationRequired)]

        //All other
        [InlineData(false, OrderType.Repair, false, false, OrderStatus.Confirmed)]
        [InlineData(true, OrderType.Repair, false, false, OrderStatus.Confirmed)]
        [InlineData(false, OrderType.Hire, false, false, OrderStatus.Confirmed)]
        [InlineData(true, OrderType.Hire, false, false, OrderStatus.Confirmed)]
        [InlineData(false, OrderType.Repair, true, false, OrderStatus.Confirmed)]
        [InlineData(false, OrderType.Hire, true, false, OrderStatus.Confirmed)]
        [InlineData(false, OrderType.Hire, false, true, OrderStatus.Confirmed)]
        [InlineData(false, OrderType.Hire, true, true, OrderStatus.Confirmed)]

        public void Test(bool isRushOrder, OrderType orderType, bool isNewCustomer, bool isLargeOrder, OrderStatus expected)
        {
            //arrange
            Mock<IRules>? ruleService = new();
            ruleService.Setup(x => x.ReadRules()).Returns(rules);
            Process? process = new(ruleService.Object);
            Inputs? testData = new()
            {
                IsLargeOrder = isLargeOrder,
                IsRushOrder = isRushOrder,
                IsNewCustomer = isNewCustomer,
                OrderType = orderType
            };

            //act
            OrderStatus output = process.ProcessOrder(testData);

            //assert
            Assert.Equal(expected, output);
        }

        //Test Data
        private readonly List<OrderRule> rules = new()
        {
            new OrderRule
            {
                Input = new Inputs
                {
                    OrderType = OrderType.Repair,
                    IsNewCustomer = true,
                    IsLargeOrder = true
                },
                OrderStatus = OrderStatus.Closed
            },
            new OrderRule
            {
                Input = new Inputs
                {
                    OrderType = OrderType.Hire,
                    IsRushOrder = true,
                    IsLargeOrder = true
                },
                OrderStatus = OrderStatus.Closed
            },
            new OrderRule
            {
                Input = new Inputs
                {
                    OrderType = OrderType.Repair,
                    IsLargeOrder = true
                },
                OrderStatus = OrderStatus.AuthorisationRequired
            },
            new OrderRule
            {
                Input = new Inputs
                {
                    IsRushOrder = true,
                    IsNewCustomer = true
                },
                OrderStatus = OrderStatus.AuthorisationRequired
            },
            new OrderRule
            {
                Input = new Inputs
                {
                },
                OrderStatus = OrderStatus.Confirmed
            }

        };
    }
}