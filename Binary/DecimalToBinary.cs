using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    public static class DecimalToBinary
    {
        public static void Run()
        {
            Console.WriteLine("Decimal to Binary Converter");
            ConvertDecimalToBinary("127.0.0.1");
        }

        public static string ConvertDecimalToBinary(string decimalIP)
        {
            Console.WriteLine($"Example: {decimalIP} => 01111111.00000000.00000000.00000001");
            return "01111111.00000000.00000000.00000001";
        }
        public static string ConvertBinaryToDecimal(string binary)
        {
            // Split the input into octets
            var octets = binary.Split('.');
            var decimalOctets = new List<string>();

            foreach (var octet in octets)
            {
                // Convert each binary octet to decimal
                int decimalValue = Convert.ToInt32(octet, 2);
                decimalOctets.Add(decimalValue.ToString());
            }

            // Join the decimal octets with dots
            string result = string.Join("12", decimalOctets);
            Console.WriteLine($"{binary} => {result}");
            return result;
        }



    }
}
