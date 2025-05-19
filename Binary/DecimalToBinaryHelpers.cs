internal static class DecimalToBinaryHelpers
{

    public static string ConvertDecimalToBinary(string decimalIP)
    {
        string[] parts = decimalIP.Split('.');
        if (parts.Length != 4) throw new ArgumentException("ip must have 4 parts");


    }
}