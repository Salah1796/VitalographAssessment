using VitalographAssessment;
using VitalographAssessment.Helper;
using VitalographAssessment.Helper.Interfaces;
using VitalographAssessment.Interfaces;

namespace VitalographAssessmentTest.CaesarCipherEncryptionTests.RunTests
{
    public class RunTests
    {
        private readonly ICaesarCipherEncryptionManager caesarCipherEncryption;
        private readonly ICaesarCipherEncryptor caesarCipherEncryptor;
        public RunTests()
        {
            caesarCipherEncryptor = new CaesarCipherEncryptor();
            caesarCipherEncryption = new CaesarCipherEncryptionManager(caesarCipherEncryptor);
        }

        [Fact]
        public void Run_ValidInput_ShouldEncrypt()
        {
            // Arrange
            var input = new StringReader("ABC\n1\nN");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            caesarCipherEncryption.Run();
            var result = output.ToString();
            var expectedOutputFull = $"Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}Enter the shift value (Click 'Enter' to use default {caesarCipherEncryption.DefaultShift}): " +
                                    $"{Environment.NewLine}Output: BCD" +
                                    $"{Environment.NewLine}Do you want to continue ({caesarCipherEncryption.ContinueCommand}/N)?" +
                                    $"{Environment.NewLine}Exiting program...{Environment.NewLine}";

            Assert.Equal(expectedOutputFull, result);
        }

        [Fact]
        public void Run_ValidInput_ShouldEncryptAndContinueOneMore()
        {
            // Arrange
            var input = new StringReader($"ABC\n1\n{caesarCipherEncryption.ContinueCommand}\nXYZ\n2\nN");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            caesarCipherEncryption.Run();
            var result = output.ToString();
            var expectedOutputFull = $"Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}Enter the shift value (Click 'Enter' to use default {caesarCipherEncryption.DefaultShift}): " +
                                    $"{Environment.NewLine}Output: BCD" +
                                    $"{Environment.NewLine}Do you want to continue ({caesarCipherEncryption.ContinueCommand}/N)?" +
                                    $"{Environment.NewLine}Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}Enter the shift value (Click 'Enter' to use default {caesarCipherEncryption.DefaultShift}): " +
                                    $"{Environment.NewLine}Output: ZAB" +
                                    $"{Environment.NewLine}Do you want to continue ({caesarCipherEncryption.ContinueCommand}/N)?" +
                                    $"{Environment.NewLine}Exiting program...{Environment.NewLine}";

            Assert.Equal(expectedOutputFull, result);
        }

        [Fact]
        public void Run_TypeExit_ShouldExitPrgram()
        {
            // Arrange
            var input = new StringReader(caesarCipherEncryption.ExitCommand);
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            caesarCipherEncryption.Run();
            var result = output.ToString();
            var expectedOutputFull = $"Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}Exiting program...{Environment.NewLine}";

            Assert.Equal(expectedOutputFull, result);
        }

        [Fact]
        public void Run_InValidInput_ShouldShowMessageAndAskUserAgainForInput()
        {
            // Arrange
            var input = new StringReader($"abc\n{caesarCipherEncryption.ExitCommand}");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            caesarCipherEncryption.Run();
            var result = output.ToString();
            var expectedOutputFull = $"Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}LogError: Input cannot be null or empty and  should contain only characters between A-Z." +
                                    $"{Environment.NewLine}Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}Exiting program...{Environment.NewLine}";

            Assert.Equal(expectedOutputFull, result);
        }

        [Fact]
        public void Run_EmptyInput_ShouldShowMessageAndAskUserAgainForInput()
        {
            // Arrange
            var input = new StringReader($"\n{caesarCipherEncryption.ExitCommand}");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            caesarCipherEncryption.Run();
            var result = output.ToString();
            var expectedOutputFull = $"Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}LogError: Input cannot be null or empty and  should contain only characters between A-Z." +
                                    $"{Environment.NewLine}Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                    $"{Environment.NewLine}Exiting program...{Environment.NewLine}";

            Assert.Equal(expectedOutputFull, result);
        }

        [Fact]
        public void Run_ValidInputAndInValidShiftValue_ShouldShowMessageAndAskUserAgainForShiftValue()
        {
            // Arrange
            var input = new StringReader($"ABC\nx\n1");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            caesarCipherEncryption.Run();
            var result = output.ToString();
            var expectedOutputFull = $"Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                     $"{Environment.NewLine}Enter the shift value (Click 'Enter' to use default {caesarCipherEncryption.DefaultShift}): " +
                                     $"{Environment.NewLine}Invalid shift value provided :x" +
                                     $"{Environment.NewLine}Enter the shift value (Click 'Enter' to use default {caesarCipherEncryption.DefaultShift}): " +
                                     $"{Environment.NewLine}Output: BCD" +
                                    $"{Environment.NewLine}Do you want to continue ({caesarCipherEncryption.ContinueCommand}/N)?" +
                                    $"{Environment.NewLine}Exiting program...{Environment.NewLine}";

            Assert.Equal(expectedOutputFull, result);
        }

        [Fact]
        public void Run_ValidInputAndClickEnter_ShouldUseSefaultShiftValue()
        {
            // Arrange
            var input = new StringReader($"ABC\n\nN");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Act
            caesarCipherEncryption.Run();
            var result = output.ToString();
            var expectedOutputFull = $"Enter a message to encrypt containing characters between A-Z (type 'exit' to close):" +
                                     $"{Environment.NewLine}Enter the shift value (Click 'Enter' to use default {caesarCipherEncryption.DefaultShift}): " +
                                     $"{Environment.NewLine}Output: FGH" +
                                    $"{Environment.NewLine}Do you want to continue ({caesarCipherEncryption.ContinueCommand}/N)?" +
                                    $"{Environment.NewLine}Exiting program...{Environment.NewLine}";

            Assert.Equal(expectedOutputFull, result);
        }
    }
}
