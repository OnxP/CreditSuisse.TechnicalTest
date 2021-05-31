using System;
using System.Collections.Generic;
using System.Linq;

namespace TechnicalTest
{
    public class InstructionEvalulation
    {
        public static int Evalulation(Dictionary<string, Instruction> dictioary)
        {
            var firstInstruciton = dictioary.Values.First();

            var result = Evalulate(firstInstruciton, dictioary);

            return result;
        }

        private static int Evalulate(Instruction instruciton, Dictionary<string, Instruction> dictioary)
        {
            var operation = instruciton.Op;

            if (instruciton.IsValue) return Convert.ToInt32(instruciton.Labels[0]);

            var result = Evalulate(dictioary[instruciton.Labels[0]], dictioary);
            for (int i = 1; i < instruciton.Labels.Length; i++)
            {
                result = operation(result, Evalulate(dictioary[instruciton.Labels[i]], dictioary));
            }
            return result;
        }
    }
}