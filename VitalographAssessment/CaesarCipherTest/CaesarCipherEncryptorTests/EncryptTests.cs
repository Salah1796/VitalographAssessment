using VitalographAssessment.Helper;
using VitalographAssessment.Helper.Interfaces;

namespace VitalographAssessmentTest.CaesarCipherEncryptorTests.EncryptTests
{
    public class EncryptTests
    {
        readonly ICaesarCipherEncryptor caesarCipher;
        public EncryptTests()
        {
            caesarCipher = new CaesarCipherEncryptor();
        }

        [Theory]
        [InlineData("HELLO", 3, "KHOOR")]
        [InlineData("WORLD", 5, "BTWQI")]
        [InlineData("ENCRYPT", 1, "FODSZQU")]
        [InlineData("XYZ", 2, "ZAB")]
        public void Encrypt_ValidInput_ReturnsExpectedResult(string input, int shift, string expectedResult)
        {
            // Act
            string encryptedText = caesarCipher.Encrypt(input, shift);

            // Assert
            Assert.Equal(expectedResult, encryptedText);
        }


        [Fact]
        public void Encrypt_EmptyInput_ReturnsEmpty()
        {
            // Act
            string encryptedText = caesarCipher.Encrypt(string.Empty, 1);

            // Assert
            Assert.Equal(string.Empty, encryptedText);
        }

        [Fact]
        public void Encrypt_ShiftZero_ReturnsInput()
        {
            // Act
            string encryptedText = caesarCipher.Encrypt("ABC", 0);

            // Assert
            Assert.Equal("ABC", encryptedText);
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("test2")]
        [InlineData("*&^%$")]
        [InlineData("Ab c")]

        public void Encrypt_InvalidCharacter_ThrowsArgumentOutOfRangeException(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => caesarCipher.Encrypt(input, 1));
        }
    }
}
