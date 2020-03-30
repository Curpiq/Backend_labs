using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;

namespace PasswordStrengthTests
{
    [TestClass]
    public class PasswordStrength_Tests
    {
        [TestMethod]
        public void ParseArg_NoArgument_FalseReturned()
        {
            string[] wrong = new string[0] { };
            string pass = "";
            bool result = Program.ParseArg(wrong, ref pass);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ParseArg_ManyArgument_FalseReturned()
        {
            string[] wrong = new string[2] { "1", "2" };
            string pass = "";
            bool result = Program.ParseArg(wrong, ref pass);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ParseArg_CorrectArgsCount_TrueReturned()
        {
            string[] correct = new string[1] { "abc" };
            string pass = "";
            bool result = Program.ParseArg(correct, ref pass);
            Assert.AreEqual(true, result);
        }

        public void ParseArg_InvalidChars_FalseReturned()
        {
            string[] correct = new string[1] { "#abc" };
            string pass = "";
            bool result = Program.ParseArg(correct, ref pass);
            Assert.AreEqual(false, result);
        }


        [TestMethod]
        public void PasswordRating_PassWithOnlySmallLetters()
        {
            string pass = "mypass";
            int result = Program.PasswordRating(pass);
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void PasswordRating_PassWithOnlyCapitalLetters()
        {
            string pass = "MYPASS";
            int result = Program.PasswordRating(pass);
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void PasswordRating_PassWithOnlyDigits()
        {
            string pass = "123456";
            int result = Program.PasswordRating(pass);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void PasswordRating__UpperAndLowCasePass()
        {
            string pass = "MyPass";
            int result = Program.PasswordRating(pass);
            Assert.AreEqual(28, result);
        }

        [TestMethod]
        public void PasswordRating_UpperAndLowCasePassWithDigits()
        {
            string pass = "MyPass123";
            int result = Program.PasswordRating(pass);
            Assert.AreEqual(70, result);
        }

        [TestMethod]
        public void CountRepetitiveChars_PassWithRepeatedChars()
        {
            string pass = "pass";
            int result = Program.CountRepetitiveChars(pass);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CountRepetitiveChars_PassWithoutRepeatedChars()
        {
            string pass = "pasword";
            int result = Program.CountRepetitiveChars(pass);
            Assert.AreEqual(0, result);
        }
    }
}
