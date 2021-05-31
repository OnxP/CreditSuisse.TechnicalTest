using System;
using System.Collections.Generic;
using System.IO;
using TechnicalTest;

namespace ConsoleApp2
{
    class Program
    {
        static Func<int, int, int> Add = (x, y) => x + y;
        static Func<int, int, int> Mult = (x, y) => x * y;
        static void Main(string[] args)
        {
            var fileName = @"input.txt";
            var dictionary = LoadDictionary(fileName);

            var results = InstructionEvalulation.Evalulation(dictionary);

            Console.WriteLine(results);

            //Output reads : 348086909
        }

        private static Dictionary<string,Instruction> LoadDictionary(string fileName)
        {
            var dictionary = new Dictionary<string, Instruction>();
            using(StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s=sr.ReadLine())!= null)
                {
                    //using dictionary assuming that the references are unique.
                    var arr = s.Split(':');
                    dictionary.Add(arr[0],ConvertToInstruction(arr[1]));
                }
            }
            return dictionary;
        }

        private static Instruction ConvertToInstruction(string sr)
        {
            //Format of string [OPP] {Labels}
            var arr = sr.Trim().Split(' ');
            var opp = arr[0];
            var labels = sr.Replace(opp, "").Trim();

            var instruction = new Instruction(opp, labels);

            instruction.SetOperator(SelectOperator(opp));
            return instruction;
        }

        private static Func<int,int,int> SelectOperator(string opp)
        {
            switch (opp)
            {//Assuming Add and Multi are the only operators there...but can add more here.
                case "Add":
                    return Add;
                case "Mult":
                    return Mult;
                case "Value":
                default:
                    return null;
            }
        }
    }
}
