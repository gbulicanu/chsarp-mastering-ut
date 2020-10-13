using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class HousekeeperServiceTests
    {
        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements() 
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Query<Housekeeper>())
                .Returns(new List<Housekeeper>
                {
                    new Housekeeper
                    {
                        Oid = 1,
                        Email = "a",
                        FullName = "b",
                        StatementEmailBody="c"
                    }
                }.AsQueryable());
            var statementGenerator = new Mock<IStatementGenerator>();
            var emailSender = new Mock<IEmailSender>();
            var xtraMessageBox = new Mock<IXtraMessageBox>();

            var housekeeperService = new HousekeeperService(
                unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                xtraMessageBox.Object);

            housekeeperService.SendStatementEmails(new DateTime(2020, 10, 12));

            statementGenerator.Verify(x => x.SaveStatement(1, "b", new DateTime(2020, 10, 12)));
        }
    }
}
