using System;
using System.Linq;

namespace BinaryConverter
{
    public static class IPConverter
    {
        public static void Run()
        {
            Console.WriteLine("IP Address Converter");
            Console.Write("Enter IP address: ");
            string ip = Console.ReadLine();

            try
            {
                bool isBinary = ip.Split('.').All(octet => octet.All(c => c == '0' || c == '1'));
                string result = isBinary ? BinaryToDecimal(ip) : DecimalToBinary(ip);
                Console.WriteLine($"Converted: {result}");
            }
            catch
            {
                Console.WriteLine("Invalid IP format. Use either:\n" +
                                "Decimal: 192.168.1.1\n" +
                                "Binary: 11000000.10101000.00000001.00000001");
            }
        }

        private static string DecimalToBinary(string ip)
        {
            return string.Join(".", ip.Split('.').Select(octet =>
                Convert.ToString(int.Parse(octet), 2).PadLeft(8, '0')));
        }

        private static string BinaryToDecimal(string ip)
        {
            return string.Join(".", ip.Split('.').Select(octet =>
                Convert.ToInt32(octet, 2).ToString()));
        }
    }
}