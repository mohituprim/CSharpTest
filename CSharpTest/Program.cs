using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace CSharpTest
{
    class Program
    {

        static void Main(string[] args)
        {
            string previous = "";
            var input = System.Console.ReadLine().Trim();
            previous = input;
            bool exist = true;
            while (exist)
            {
                if (previous.Contains("()"))
                {
                    previous = previous.Replace("()", String.Empty);
                    exist = true;
                }
                else
                {
                    exist = false;
                }
            }
            int open=0;
            int close=0;
            int l = previous.Length;
            for (int count = 0; count < l; count++)
            {
                if (previous[count] == '(')
                    open++;
                else
                    close++;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(input);
            
            for (; open >0; open--)
            {
                sb.Insert(0,'(');
                input.Insert(0, "(");
            }
            for (; close >0; close--)
            {
                sb.Insert(sb.Length, ')');
                input.Insert(input.Length-1, ")");
            }

            var line1 = System.Console.ReadLine().Trim();
            var N = Int32.Parse(line1);
            for (var i = 0; i < N; i++)
            {
                var inputstring = System.Console.ReadLine().Trim();
                var weightLine = System.Console.ReadLine().Trim();
                int[] weigthArray = weightLine.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

                inputstring.ToLower();
                var TL = inputstring.Length;
                int TW = 0;
                int[] countChar = new int[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int j = 0; j < TL; j++)
                {
                    if (countChar[inputstring[j] - 97] == 0)
                        TW += weigthArray[inputstring[j] - 97];
                    countChar[inputstring[j] - 97]++;
                }

                float spa = 0;
                for (int j = 0; j < 26; j++)
                {
                    spa += countChar[j] * weigthArray[j];
                }

                spa = (10 * spa) / (TL * TW);
                Math.Round((Decimal)spa, 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}
