using VitalographAssessment.Helper;
using VitalographAssessment.Helper.Interfaces;

namespace VitalographAssessmentTest.CaesarCipherEncryptorTests.ValidCharacterTests
{

    public class ValidCharacterTests
    {
        ICaesarCipherEncryptor caesarCipher;
        public ValidCharacterTests()
        {
            caesarCipher = new CaesarCipherEncryptor();
        }

        [Theory]
        [InlineData('A', true)]
        [InlineData('Z', true)]
        [InlineData('a', false)] // Lowercase character
        [InlineData('1', false)] // Non-alphabet character
        [InlineData('&', false)] // Non-alphabet character
        [InlineData(' ', false)] // Non-alphabet character

        public void ValidCharacter_ValidInput_ReturnsExpectedResult(char character, bool expectedResult)
        {
            // Act
            bool isValid = caesarCipher.ValidCharacter(character);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
