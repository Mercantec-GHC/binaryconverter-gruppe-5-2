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
            string binaryIP = "01111111.00000000.00000000.00000001";
            Console.WriteLine($"Binary IP: {binaryIP}");
            string decimalIP = ConvertBinaryToDecimal(binaryIP);
            Console.WriteLine($"Decimal IP: {decimalIP}");
        }

        public static string ConvertBinaryToDecimal(string binary)
        {
            List<int> powerOfTwos = new List<int>() { 128, 64, 32, 16, 8, 4, 2, 1 };
            string[] octets = binary.Split('.');
            List<string> decimalOctets = new List<string>();

            foreach (string octet in octets)
            {
                int sum = 0;
                for (int i = 0; i < octet.Length; i++)
                {
                    int digit = octet[i] - '0';
                    int powerOfTwo = powerOfTwos[i];
                    sum += digit * powerOfTwo;
                }
                decimalOctets.Add(sum.ToString());
            }

            return string.Join(".", decimalOctets);
        }
    }
}
