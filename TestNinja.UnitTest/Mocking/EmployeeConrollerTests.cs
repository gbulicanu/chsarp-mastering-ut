using Moq;

using NUnit.Framework;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class EmployeeConrollerTests
    {
        private Mock<IEmployeeStorage> employeeStorage;
        private EmployeeController employeeController;

        [SetUp]
        public void SetUp()
        {
            this.employeeStorage = new Mock<IEmployeeStorage>();
            this.employeeController =
                new EmployeeController(this.employeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_CallsDeleteOnStorage()
        {
            this.employeeController.DeleteEmployee(1);

            this.employeeStorage.Verify(x => x.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnRedirectResult()
        {
            var result = this.employeeController.DeleteEmployee(1);

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
