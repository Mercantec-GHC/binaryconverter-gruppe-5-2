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
            Console.Write("Enter a binary IP address (format: 8 bits per octet, separated by dots): ");
            string binaryIP = Console.ReadLine();  //stores input
            if (string.IsNullOrEmpty(binaryIP) || !IsValidBinaryIP(binaryIP))
            {
                Console.WriteLine("Invalid binary IP address. Please enter a valid format like 01111111.00000000.00000000.00000001.");
                return;
            }
            Console.WriteLine($"Binary IP: {binaryIP}");
            string decimalIP = ConvertBinaryToDecimal(binaryIP);
            Console.WriteLine($"Decimal IP: {decimalIP}");
        }

        public static bool IsValidBinaryIP(string binaryIP)
        {
            // Check if the binary IP address consists of 4 octets of 1 to 8 bits each
            string[] octets = binaryIP.Split('.');
            if (octets.Length != 4) return false;
            foreach (string octet in octets)
            {
                if (octet.Length == 0 || octet.Length > 8) return false;
                foreach (char c in octet)
                {
                    if (c != '0' && c != '1') return false;
                }
            }
            return true;
        }

        public static string ConvertBinaryToDecimal(string binary)
        {
            // biostrong = 10101010 => 170 - 128 + 32 + 8 + 2
            // StringSequence 128 64 32 16 8 4 2 1
            string[] octets = binary.Split('.');
            List<string> decimalOctets = new List<string>();

            foreach (string octet in octets)
            {
                int sum = 0;
                int power = 128;
                for (int i = 0; i < octet.Length; i++)
                {
                    int digit = octet[i] - '0';
                    sum += digit * power;
                    power /= 2;
                }
                decimalOctets.Add(sum.ToString());
            }

            return string.Join(".", decimalOctets);
        }

        public static void Main()
        {
            Run();
        }
    }
}
