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
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] < 65 || input[i] > 90)
                    {
                        throw new Exception("Only A-Z supported.");
                    }
                    int shifted = input[i] + shift;
                    if (shifted > 90)
                    {
                        shifted = 65 + shifted - 91;
                    }
                    output = output + (char)shifted;
                }
            }
            Console.WriteLine("Output: " + output);
        }
    }
}
