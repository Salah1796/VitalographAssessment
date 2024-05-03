using Serilog;
namespace Encryption.CaesarCipher
{
    public class Program
    {
        /// <summary>
        /// The default shift value used for encryption if no shift value is provided.
        /// </summary>
        const int DefaultShift = 5;

        public static void Main(string[] args)
        {
            // Configure Serilog for logging
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File("logs/caesarCipher.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

            Log.Information("Program started.");

            bool continueProgram;
            do
            {
                string input = GetInputString();
                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    Log.Information("User type 'exit' Exiting program...");
                    Console.WriteLine("Exiting program...");
                    break;
                }
                int shift = GetShiftValue();
                EncryptAndPrintResult(input, shift);
                Log.Debug("Waiting for user type Y or N to continue ");
                Console.Write("Do you want to continue (Y/N)? ");
                string? response = Console.ReadLine();
                continueProgram = response?.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase) ?? false;
                if (!continueProgram)
                    Log.Information($"User type {response} Exiting program...");
            } while (continueProgram);

            Log.Information("Program finished.");
            Log.CloseAndFlush();
        }

        private static void EncryptAndPrintResult(string input, int shift)
        {
            try
            {
                Log.Information("Encrypting Input: {Input}, Shift: {Shift}", input, shift);
                string encrypted = CaesarCipher.Encrypt(input, shift);
                string result = "Output: " + encrypted;
                Console.WriteLine(result);
                Log.Information(result);
            }
            catch (Exception ex)
            {
                string errorMessage = "An unexpected error occurred: " + ex.Message;
                Console.WriteLine(errorMessage);
                Log.Error(ex, errorMessage);
            }
        }

        /// <summary>
        /// Get input string from the user, ensuring it contains characters between A-Z or exit
        /// </summary>
        /// <returns>The input string entered by the user.</returns>
        private static string GetInputString()
        {
            Log.Debug("Waiting for user input...");
            bool isValid = false;
            string? input = string.Empty;
            do
            {
                Console.Write("Enter a message to encrypt containing characters between A-Z (type 'exit' to close): ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Log.Warning("Empty input string provided.");
                    Console.WriteLine("Error: Input string cannot be null or empty.");
                    isValid = false;
                }
                else if (input != "exit" && input.Any(ch => ch < 'A' || ch > 'Z'))
                {
                    Log.Warning("Invalid characters detected. Please enter only characters between A-Z.");
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
        /// <returns>The shift value entered by the user</returns>
        private static int GetShiftValue()
        {
            Log.Debug("Waiting for user input for shift value...");
            int shift;
            do
            {
                Console.Write($"Enter the shift value (Click 'Enter' to use default {DefaultShift}): ");
                string? shiftInput = Console.ReadLine();
                if (string.IsNullOrEmpty(shiftInput))
                {
                    Log.Information("User clicked 'Enter' for shift value use default {DefaultShift}", DefaultShift);
                    return DefaultShift;
                }
                if (!int.TryParse(shiftInput, out shift))
                {
                    Log.Warning("Invalid shift value provided : {shiftInput} ", shiftInput);
                    Console.WriteLine($"Invalid shift value provided : {shiftInput} ");
                }
            } while (shift == 0);
            return shift;
        }
    }
}
