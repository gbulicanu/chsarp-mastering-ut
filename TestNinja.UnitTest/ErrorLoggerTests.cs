﻿using NUnit.Framework;

using System;

using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetLastErrorProperty() 
        {
            var errorLogger = new ErrorLogger();
            const string errorMessage = "a";

            errorLogger.Log(errorMessage);

            Assert.That(errorLogger.LastError, Is.EqualTo(errorMessage));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowsArgumentNullException(string error)
        {
            var errorLogger = new ErrorLogger();

            Assert.That(
                () => errorLogger.Log(error),
                Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaisesErrorLoggedEvent()
        {
            var errorLogger = new ErrorLogger();
            var id = Guid.Empty;

            errorLogger.ErrorLogged += (sender, args) => { id = args; };
            errorLogger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
