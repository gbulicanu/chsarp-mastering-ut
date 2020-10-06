using Moq;

using NUnit.Framework;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PaceOrder_WhenCalled_CallsStorage()
        {
            var storage = new Mock<IStorage>();
            var orderService = new OrderService(storage.Object);
            var order = new Order();

            orderService.PlaceOrder(order);

            storage.Verify(x => x.Store(order));
        }
    }
}
