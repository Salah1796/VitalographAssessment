using Serilog;
namespace Encryption.CaesarCipher
{
    public class Program
    {
        /// <summary>
        /// The default shift value used for encryption if no shift value is provided.
        /// </summary>
        const int DefaultShift = 5;
        private const string ExitCommand = "exit";
        private const string ContinueCommand = "Y";

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
                if (input.Equals(ExitCommand, StringComparison.CurrentCultureIgnoreCase))
                {
                    Log.Information("User type {exit} Exiting program...", input);
                    Console.WriteLine("Exiting program...");
                    break;
                }
                int shift = GetShiftValue();
                EncryptAndPrintResult(input, shift);
                Log.Debug("Waiting for user type {ContinueCommand} to continue ", ContinueCommand);
                Console.Write($"Do you want to continue ({ContinueCommand}/N)? ");
                string? response = Console.ReadLine();
                continueProgram = response?.Trim().Equals(ContinueCommand, StringComparison.OrdinalIgnoreCase) ?? false;
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
            bool isValid;
            string? input;
            do
            {
                Console.Write("Enter a message to encrypt containing characters between A-Z (type 'exit' to close): ");
                input = Console.ReadLine();
                isValid = IsValidInput(input);
                if (!isValid)
                {
                    Console.WriteLine("Error: Input annot be null or empty and  should contain only characters between A-Z.");
                    Log.Warning("Invalid user Input {input}.", input);
                }
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

        /// <summary>
        /// Validates the input string to ensure it not null or empty and  contains characters between A-Z or is the exit command.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the input is valid; otherwise, false.</returns>
        private static bool IsValidInput(string? input)
        {
            if (string.IsNullOrEmpty(input) || (input != ExitCommand && input.Any(ch => !CaesarCipher.ValidCharacter(ch))))
                return false;
            return true;
        }
    }
}
