using Shop;

namespace ShopTest
{
    public class ShopTest : IDisposable
    {
        Order testOrder;
        public TestOrder()
        {
            testOrder = new Order();
            testOrder.Person = new Person();
            testOrder.Person.Name = "Testy";
            testOrder.Person.Address = "Teststreet";
            testOrder.Amount = 1;
            testOrder.Date = DateTime.Now;
        }

        public void Dispose()
        {
            //quit
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(11, 0.05)]
        [InlineData(111, 0.15)]
        public void TestDiscount(double amount, double discount)
        {
            testOrder.Amount = amount;
            Double expected = 98.99 * amount - 98.99 * discount * 0.05;
            Double actual = testOrder.TotalSum();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDiscount0()
        {
            testOrder.Amount = 1;
            Double expected = 98.99;
            Double actual = testOrder.TotalSum();
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestDiscount5()
        {
            testOrder.Amount = 11;
            Double expected = 98.99 * testOrder.Amount - 98.99 * testOrder.Amount * 0.05;
            Double actual = testOrder.TotalSum();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDiscount15()
        {
            testOrder.Amount = 111;
            Double expected = 98.99 * testOrder.Amount - 98.99 * testOrder.Amount * 0.15;
            Double actual = testOrder.TotalSum();
            Assert.Equal(expected, actual);
        }
    }
}