namespace BankSystem.Client.Core.Helper
{
    using System;
    using System.Text;

    public static class RandomGenerator
    {

        private const string ALPHABET = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random rnd = new Random();

        public static string GenerateString(int len)
        {

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                result.Append(ALPHABET[rnd.Next(0, ALPHABET.Length)]);
            }
            return result.ToString();
        }
    }
}
