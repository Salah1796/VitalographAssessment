namespace VitalographAssessment.Helper.Interfaces
{
    public interface ICaesarCipherEncryptor
    {
        /// <summary>
        /// Encrypts the input string using the Caesar cipher algorithm with the specified shift.
        /// </summary>
        /// <param name="input">The input string to encrypt.</param>
        /// <param name="shift">The shift value for encryption.</param>
        /// <returns>The encrypted string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the input string contains characters outside the range of A-Z.</exception>
        string Encrypt(string input, int shift);

        /// <summary>
        /// Validates the character between A-Z 
        /// </summary>
        /// <param name="character">The character  to validate</param>
        /// <returns>True if the character is valid; otherwise, false.</returns>
        bool ValidCharacter(char character);
    }
}