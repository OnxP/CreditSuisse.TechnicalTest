using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest
{
    [TestClass]
    public class UnitTests
    {
        Func<int, int, int> Add = (x, y) => x + y;
        Func<int, int, int> Mult = (x, y) => x * y;
        [TestMethod]
        public void EvalulateSimpleAddFunction_True()
        {
            var dictioary = new Dictionary<string, Instruction>();
            dictioary.Add("0", new Instruction("Add", "1 2",Add));
            dictioary.Add("1", new Instruction("Value", "3"));
            dictioary.Add("2", new Instruction("Value", "5"));

            var result = InstructionEvalulation.Evalulation(dictioary);

            Assert.AreEqual(8, result);
        }
        [TestMethod]
        public void EvalulateSimpleMultiplyFunction_True()
        {
            var dictioary = new Dictionary<string, Instruction>();
            dictioary.Add("0", new Instruction("Mult", "1 2",Mult));
            dictioary.Add("1", new Instruction("Value", "3"));
            dictioary.Add("2", new Instruction("Value", "5"));

            var result = InstructionEvalulation.Evalulation(dictioary);
            Assert.AreEqual(15, result);
        }
        [TestMethod]
        public void EvalulateAddFunction_3_True()
        {
            var dictioary = new Dictionary<string, Instruction>();
            dictioary.Add("0", new Instruction("Add", "1 2 3",Add));
            dictioary.Add("1", new Instruction("Value", "3"));
            dictioary.Add("2", new Instruction("Value", "5"));
            dictioary.Add("3", new Instruction("Value", "6"));

            var result = InstructionEvalulation.Evalulation(dictioary);
            Assert.AreEqual(14, result);
        }
        [TestMethod]
        public void EvalulateMultiplyFunction_3_True()
        {
            var dictioary = new Dictionary<string, Instruction>();
            dictioary.Add("0", new Instruction("Mult", "1 2 3",Mult));
            dictioary.Add("1", new Instruction("Value", "3"));
            dictioary.Add("2", new Instruction("Value", "5"));
            dictioary.Add("3", new Instruction("Value", "6"));

            var result = InstructionEvalulation.Evalulation(dictioary);
            Assert.AreEqual(90, result);
        }
        [TestMethod]
        public void EvalulateChainFunction_True()
        {
            var dictioary = new Dictionary<string, Instruction>();
            dictioary.Add("0", new Instruction("Add", "4 4 1",Add));
            dictioary.Add("1", new Instruction("Mult", "6 2", Mult));
            dictioary.Add("2", new Instruction("Value", "-3"));
            dictioary.Add("3", new Instruction("Add", "6 1 2",Add));
            dictioary.Add("4", new Instruction("Value", "5"));
            dictioary.Add("6", new Instruction("Value", "2"));

            var result = InstructionEvalulation.Evalulation(dictioary);
            Assert.AreEqual(4, result);
        }
    }
}
