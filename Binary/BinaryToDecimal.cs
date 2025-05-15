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
            Console.Write("Enter a binary IP address: ");
            string binaryIP = Console.ReadLine();
            if (string.IsNullOrEmpty(binaryIP) || !IsValidBinaryIP(binaryIP))
            {
                Console.WriteLine("Invalid binary IP address.");
                return;
            }
            Console.WriteLine($"Binary IP: {binaryIP}");
            string decimalIP = ConvertBinaryToDecimal(binaryIP);
            Console.WriteLine($"Decimal IP: {decimalIP}");
        }

        public static bool IsValidBinaryIP(string binaryIP)
        {
            string[] octets = binaryIP.Split('.');
            if (octets.Length != 4) return false;
            foreach (string octet in octets)
            {
                if (octet.Length != 8 || !octet.All(c => c == '0' || c == '1'))
                    return false;
            }
            return true;
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

        public static void Main()
        {
            Run();
        }
    }
}
