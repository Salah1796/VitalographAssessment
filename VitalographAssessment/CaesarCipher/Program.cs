namespace Encryption.CaesarCipher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int shift = 5;
            string output = "";
            Console.Write("Input: ");
            string input = GetInputString();
            if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Exiting program...");
                return;
            }
            if (input != null)
                output = CaesarCipher.Encrypt(input, shift);
            Console.WriteLine("Output: " + output);
        }

        /// <summary>
        /// Get input string from the user, ensuring it contains characters between A-Z or exit
        /// </summary>
        /// <returns>The input string entered by the user.</returns>
        private static string GetInputString()
        {
            bool isValid = false;
            string? input = string.Empty;
            do
            {
                Console.Write("Enter a message to encrypt containing characters between A-Z (type 'exit' to close): ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Error: Input string cannot be null or empty.");
                    isValid = false;
                }
                else
                    isValid = true;
            } while (!isValid);
            return input!;
        }
    }
}
