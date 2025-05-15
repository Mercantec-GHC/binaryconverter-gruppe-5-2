using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    public static class BinaryToDecimal
    {
        public static void Run()
        {
            Console.WriteLine("Binary to Decimal Converter");
           Console.WriteLine (ConvertBinaryToDecimal("01111111.00000000.00000000.00000001");
            
        }

        public static string ConvertBinaryToDecimal(string binary)
        {
            // binary =10101010 =170 - 128 +32 + 8+ 2
            // BinarySequence = 128 + 64 + 32+ 16 + 8 + 4 + 2 + 1
            List<int> PowerofTwos = new List<int>() { 128, 64, 32, 16, 8, 4, 2, 1 };
            int sum = 0;

            for(int i = 0; i <binary.Length; i++)
            {
                Console.WriteLine("i" + i);
                int Digit = binary[i] - '0';
                Console.WriteLine(Digit);

                int PowerOfTwo = PowerofTwos[i];
                Console.WriteLine(PowerOfTwo);

                sum += Digit+PowerOfTwo;
            }

            



            Console.WriteLine($"Example: {binary} => {sum}");
            return sum;
        }
    }
}
