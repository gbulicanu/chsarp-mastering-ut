using Moq;

using NUnit.Framework;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };
            var customer = new Customer { IsGold = true };

            var result = product.GetPrice(customer);

            Assert.That(result, Is.EqualTo(70));
        }

        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount2()
        {
            var product = new Product { ListPrice = 100 };
            var customer = new Mock<ICustomer>();
            customer.Setup(x => x.IsGold).Returns(true);

            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(70));
        }
    }
}
