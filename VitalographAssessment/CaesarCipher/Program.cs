namespace Encryption.CaesarCipher
{
    public class Program
    {
        /// <summary>
        /// The default shift value used for encryption if no shift value is provided by user
        /// </summary>
        public const int DefaultShift = 5;
        public static void Main(string[] args)
        {
            string input = GetInputString();
            if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Exiting program...");
                return;
            }
            EncryptAndPrintResult(input, GetShiftValue());
        }

        private static void EncryptAndPrintResult(string input, int shift)
        {
            try
            {
                string encrypted = CaesarCipher.Encrypt(input, shift);
                string result = "Output: " + encrypted;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                string errorMessage = "An unexpected error occurred: " + ex.Message;
                Console.WriteLine(errorMessage);
            }
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
                else if (input != "exit" && input.Any(ch => ch < 'A' || ch > 'Z'))
                {
                    Console.WriteLine("Error: Input should contain only characters between A-Z.");
                    isValid = false;
                }
                else
                    isValid = true;
            } while (!isValid);
            return input!;
        }


        /// <summary>
        /// Get shift value for encryption
        /// </summary>
        /// <returns>The shift value entered by the user or default </returns>
        private static int GetShiftValue()
        {
            int shift;
            do
            {
                Console.Write($"Enter the shift value (Click 'Enter' to use default {DefaultShift}): ");
                string? shiftInput = Console.ReadLine();
                if (string.IsNullOrEmpty(shiftInput))
                    return DefaultShift;
                if (!int.TryParse(shiftInput, out shift))
                    Console.WriteLine($"Invalid shift value provided : {shiftInput} ");
            } while (shift == 0);
            return shift;
        }
    }
}
