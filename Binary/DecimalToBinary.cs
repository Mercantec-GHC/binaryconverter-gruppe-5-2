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
            {3
                string binary = ConvertDecimalToBinary(ip);
                Console.WriteLine($"Converted: {binary}");
            }
            catch
            {
                Console.WriteLine("invalid ip format. Use 4 numbers (0-255) separated by dots.");
            }
        }

        public static string ConvertDecimalToBinary(string decimalIP)
        {
            string[] parts = decimalIP.Split('.');
            if (parts.Length != 4) throw new ArgumentException("ip must have 4 parts");

         
        }
   }

    }





