using System;
using System.Linq;

namespace BinaryConverter
{
    public static class DecimalToBinary
    {
        public static void Run()
        {
            Console.WriteLine("Decimal to Binary Converter");
            Console.Write("Enter a decimal IP address (e.g., 127.0.0.1): ");
            string decimalIP = Console.ReadLine();

            try
            {
                string binaryResult = ConvertDecimalToBinary(decimalIP);
                Console.WriteLine($"Converted result: {binaryResult}");

                // Bonus: Show the reverse conversion
                string decimalResult = ConvertBinaryToDecimal(binaryResult);
                Console.WriteLine($"Verification (binary back to decimal): {decimalResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static string ConvertDecimalToBinary(string decimalIP)
        {
            // Split the IP into octets
            string[] octets = decimalIP.Split('.');

            if (octets.Length != 4)
            {
                throw new ArgumentException("Invalid IP address format. Must have 4 octets separated by dots.");
            }

            // Convert each octet to binary
            string[] binaryOctets = new string[4];
            for (int i = 0; i < 4; i++)
            {
                if (!int.TryParse(octets[i], out int octetValue) || octetValue < 0 || octetValue > 255)
                {
                    throw new ArgumentException($"Invalid octet value: {octets[i]}. Must be between 0 and 255.");
                }

                binaryOctets[i] = Convert.ToString(octetValue, 2).PadLeft(8, '0');
            }

            return string.Join(".", binaryOctets);
        }

        // Added bonus method to convert binary back to decimal
        public static string ConvertBinaryToDecimal(string binaryIP)
        {
            string[] binaryOctets = binaryIP.Split('.');

            if (binaryOctets.Length != 4)
            {
                throw new ArgumentException("Invalid binary IP format. Must have 4 octets separated by dots.");
            }

            string[] decimalOctets = new string[4];
            for (int i = 0; i < 4; i++)
            {
                if (binaryOctets[i].Length != 8 || binaryOctets[i].Any(c => c != '0' && c != '1'))
                {
                    throw new ArgumentException($"Invalid binary octet: {binaryOctets[i]}. Must be 8 binary digits.");
                }

                decimalOctets[i] = Convert.ToInt32(binaryOctets[i], 2).ToString();
            }

            return string.Join(".", decimalOctets);
        }
    }
}