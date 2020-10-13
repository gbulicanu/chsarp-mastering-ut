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
        private string statementFilename;

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

            this.unitOfWork = new Mock<IUnitOfWork>();
            this.unitOfWork.Setup(x => x.Query<Housekeeper>())
                .Returns(new List<Housekeeper> { housekeeper }.AsQueryable());

            this.statementFilename = "filename";
            this.statementGenerator = new Mock<IStatementGenerator>();
            this.statementGenerator.Setup(
                x => x.SaveStatement(
                    housekeeper.Oid,
                    housekeeper.FullName,
                    this.statementDate))
                .Returns(() => this.statementFilename);
            this.emailSender = new Mock<IEmailSender>();
            this.xtraMessageBox = new Mock<IXtraMessageBox>();

            this.service = new HousekeeperService(
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

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HousekeepersEmail_ShouldNotGenerateStatements(
            string email)
        {
            this.housekeeper.Email = email;
            this.service.SendStatementEmails(this.statementDate);

            this.statementGenerator.Verify(x => x.SaveStatement(
                housekeeper.Oid,
                housekeeper.FullName,
                this.statementDate), Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_ShouldEmailTheStatements()
        {
            this.service.SendStatementEmails(this.statementDate);

            this.emailSender.Verify(x => x.EmailFile(
                housekeeper.Email,
                housekeeper.StatementEmailBody,
                this.statementFilename,
                It.IsAny<string>()));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatementFileNameIs_ShouldNotEmailTheStatements(
            string statementFilename)
        {
            this.statementFilename = statementFilename;

            this.service.SendStatementEmails(this.statementDate);

            this.emailSender.Verify(x => x.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayMessageBox()
        {
            this.emailSender.Setup(x => x.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>())).Throws<Exception>();

            this.service.SendStatementEmails(this.statementDate);

            this.xtraMessageBox.Verify(x => x.Show(
                It.IsAny<string>(),
                It.IsAny<string>(),
                MessageBoxButtons.OK));
        }
    }
}
