namespace Encryption.CaesarCipher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int shift = 5;
            string output = "";
            Console.Write("Input: ");
            string? input = Console.ReadLine();
            if (input != null)
                output = CaesarCipher.Encrypt(input, shift);
            Console.WriteLine("Output: " + output);
        }
    }
}
