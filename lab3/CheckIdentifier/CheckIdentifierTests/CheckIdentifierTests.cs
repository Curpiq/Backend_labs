using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;
namespace CheckIdentifierTests
{
    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void BeginWithDigit()
        {
            string[] wrong = new string[1] { "5ABC" };
            int result = Program.Main(wrong);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void IncorrectSymbol()
        {
            string[] wrong = new string[1] { "dkl1#" };
            int result = Program.Main(wrong);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void CorrectArg()
        {
            string[] correct = new string[1] { "sDN12V5" };
            int result = Program.Main(correct);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ManyArguments()
        {
            string[] wrong = new string[2] { "1", "2" };
            int result = Program.Main(wrong);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void FewArguments()
        {
            string[] wrong = new string[0] { };
            int result = Program.Main(wrong);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void IncorrectLetter()
        {
            string[] wrong = new string[1] { "VF1ялн" };
            int result = Program.Main(wrong);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void EmptyString()
        {
            string[] wrong = new string[1] { "" };
            int result = Program.Main(wrong);
            Assert.AreEqual(1, result);
        }
    }
}
