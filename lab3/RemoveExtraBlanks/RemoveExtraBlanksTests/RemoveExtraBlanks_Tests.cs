using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class RemoveExtraBlanks_Tests
    {
        [TestMethod]
        public void ParseArgs_NoArguments_FalseReturned()
        {
            string[] wrong = new string[0] { };
            string fileName = "";
            bool result = Program.ParseArgs(wrong, ref fileName, ref fileName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ParseArgs_ManyArguments_FalseReturned()
        {
            string[] wrong = new string[3] { "1", "2", "3" };
            string fileName = "";
            bool result = Program.ParseArgs(wrong, ref fileName, ref fileName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ParseArgs_FewArguments_FalseReturned()
        {
            string[] wrong = new string[1] { "1" };
            string fileName = "";
            bool result = Program.ParseArgs(wrong, ref fileName, ref fileName);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ParseArgs_CorrectArgsCount_TrueReturned()
        {
            string[] correct = new string[2] { "input.txt", "output.txt" };
            string fileName = "";
            bool result = Program.ParseArgs(correct, ref fileName, ref fileName);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RemoveRepetitiveBlanksInLine_Test()
        {
            string str = " Hello    world     ! ";
            string expected = " Hello world ! ";
            string result = Program.RemoveRepetitiveBlanksInLine(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveExtraBlanksInLine_Line_With_Blanks_In_The_Beginning_And_End()
        {
            string str = " Hello    world     ! ";
            string expected = "Hello world !";
            string result = Program.RemoveExtraBlanksInLine(str);
            Assert.AreEqual(expected, result);
        }
    }
}
