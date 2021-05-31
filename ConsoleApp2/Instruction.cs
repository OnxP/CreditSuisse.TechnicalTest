using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest
{
    public class Instruction
    {
        public Instruction(string operation, string labels)
        {
            Operation = operation;
            _labels = labels;
        }
        public Instruction(string operation, string labels, Func<int, int, int> op) : this(operation,labels)
        {
            Op = op;
        }

        public void SetOperator(Func<int, int, int> op)
        {
            Op = op;
        }
        public string Operation { get; set; }

        public bool IsValue => Operation == "Value";

        string _labels { get; set; }

        public string[] Labels { get { return _labels.Split(' '); } }

        public Func<int, int, int> Op;
    }
}
