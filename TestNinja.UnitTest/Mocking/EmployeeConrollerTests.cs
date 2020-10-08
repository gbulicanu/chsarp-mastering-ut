using Moq;

using NUnit.Framework;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class EmployeeConrollerTests
    {
        private Mock<IEmployeeStorage> emplyeeStorage;
        private EmployeeController employeeController;

        [SetUp]
        public void SetUp() 
        {
            this.emplyeeStorage = new Mock<IEmployeeStorage>();
            this.employeeController =
                new EmployeeController(this.emplyeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_CallsDeleteOnStorage()
        {
            this.employeeController.DeleteEmployee(1);

            this.emplyeeStorage.Verify(x => x.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmplyee_WhenCalled_ReturnRedirectResult()
        {
            var result = this.employeeController.DeleteEmployee(1);

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
