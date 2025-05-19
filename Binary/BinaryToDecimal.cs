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
                Console.Write("Indtast en binær IP-adresse (format: 8 bit pr. oktet, adskilt med punktummer): ");
                string binaryIP = Console.ReadLine();

                // kigger om inputtet er gyldigt
                if (string.IsNullOrEmpty(binaryIP) || !IsValidBinaryIP(binaryIP))
                {
                    Console.WriteLine("Ugyldig binær IP-adresse. Indtast venligst et gyldigt format som 01111111.00000000.00000000.00000001.");
                    return;
                }

                Console.WriteLine($"Binær IP: {binaryIP}");

                // laver den binary IP til decimal
                string decimalIP = ConvertBinaryToDecimal(binaryIP);
                Console.WriteLine($"Decimal IP: {decimalIP}");
            }

            // er de right om den indtastede binære IP er korrekt formateret
            public static bool IsValidBinaryIP(string binaryIP)
            {
                // Deler IP-adressen op i 4 oktetter
                string[] octets = binaryIP.Split('.');
                if (octets.Length != 4) return false; // der skal være præcis 4 oktetter

                foreach (string octet in octets)
                {
                    if (octet.Length == 0 || octet.Length > 8) return false; // hver nummer skal være mellem 1 og 8 bit

                    foreach (char c in octet)
                    {
                        if (c != '0' && c != '1') return false; // hver nummer skal være enten '0' eller '1'
                    }
                }

                return true; // hvis alle tjek er rigtig, returner true
            }

            // laver binære oktetter til decimalform
            public static string ConvertBinaryToDecimal(string binary)
            {
                // Deler den binary IP-adresse op i oktetter
                string[] octets = binary.Split('.');
                List<string> decimalOctets = new List<string>();

                foreach (string octet in octets)
                {
                    int sum = 0;
                    int power = 128; // Starter med højeste vægt (venstre bit i 8-bit binært tal)

                    for (int i = 0; i < octet.Length; i++)
                    {
                        int digit = octet[i] - '0'; // laver karakter til tal
                        sum += digit * power; 
                        power /= 2; // Går til næste lavere vægt (f.eks. 128 → 64 → 32 osv.)
                    }

                    decimalOctets.Add(sum.ToString()); // Tilføjer det decimale resultat som en streng
                }

                return string.Join(".", decimalOctets); // Samler oktetterne med punktummer
            }
        // lmao
         
            public static void Main()
            {
                Run();
            }
        }
    }
