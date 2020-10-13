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
        private Housekeeper housekeeper;
        private Mock<IUnitOfWork> unitOfWork;
        private DateTime statementDate = new DateTime(2020, 10, 12);
        private Mock<IStatementGenerator> statementGenerator;
        private Mock<IEmailSender> emailSender;
        private Mock<IXtraMessageBox> xtraMessageBox;
        private HousekeeperService service;

        [SetUp]
        public void SetUp()
        {
            this.housekeeper = new Housekeeper
            {
                Oid = 1,
                Email = "a",
                FullName = "b",
                StatementEmailBody = "c"
            };

            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Query<Housekeeper>())
                .Returns(new List<Housekeeper> { housekeeper }.AsQueryable());
            statementGenerator = new Mock<IStatementGenerator>();
            emailSender = new Mock<IEmailSender>();
            xtraMessageBox = new Mock<IXtraMessageBox>();

            service = new HousekeeperService(
                unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                xtraMessageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements() 
        {
            this.service.SendStatementEmails(this.statementDate);

            this.statementGenerator.Verify(x => x.SaveStatement(
                housekeeper.Oid,
                housekeeper.FullName,
                this.statementDate));
        }
    }
}
