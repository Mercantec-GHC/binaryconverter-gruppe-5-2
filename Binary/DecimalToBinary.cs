using System;
using System.Linq;

namespace BinaryConverter
{
    public static class DecimalToBinary
    {
        public static void Run()
        {
            Console.WriteLine("Decimal to Binary Converter");
            Console.Write("Enter decimal IP (e.g. 192.168.1.1): ");
            string ip = Console.ReadLine();

            try
            {
                string binary = ConvertDecimalToBinary(ip);
                Console.WriteLine("Converted: " + binary);
            }
            catch
            {
                Console.WriteLine("Invalid IP format. Use 4 numbers (0-255) separated by dots.");
            }
        }

        public static string ConvertDecimalToBinary(string ip)
        {
            // Convert each decimal octet to an 8-bit binary string
            string[] octets = ip.Split('.');
            if (octets.Length != 4)
            {
                throw new FormatException();
            }

            string binaryIP = "";
            foreach (string octet in octets)
            {
                int num = int.Parse(octet);
                string binary = "";
                for (int i = 0; i < 8; i++)
                {
                    int bit = num % 2;
                    binary = bit + binary;
                    num = num / 2;
                }
                binaryIP += binary + ".";
            }

            return binaryIP.TrimEnd('.');
        }

        public static void Main()
        {
            Run();
        }
    }
}
