using System.Text;

namespace Encryption.CaesarCipher
{
    /// <summary>
    /// Provides methods for encrypting messages using the Caesar cipher algorithm.
    /// </summary>
    public class CaesarCipher
    {
        /// <summary>
        /// Encrypts the input string using the Caesar cipher algorithm with the specified shift.
        /// </summary>
        /// <param name="input">The input string to encrypt.</param>
        /// <param name="shift">The shift value for encryption.</param>
        /// <returns>The encrypted string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the input string contains characters outside the range of A-Z.</exception>
        public static string Encrypt(string input, int shift)
        {
            StringBuilder encryptedText = new();
            foreach (char character in input)
            {
                if (!ValidCharacter(character))
                    throw new ArgumentOutOfRangeException($"'{character}' is out of range (Only A-Z supported.)");
                int shifted = character + shift;
                if (shifted > 'Z')
                    shifted -= 26;//alphabet size
                encryptedText.Append((char)shifted);
            }
            return encryptedText.ToString();
        }


        /// <summary>
        /// Validates the character between A-Z 
        /// </summary>
        /// <param name="character">The character  to validate</param>
        /// <returns>True if the character is valid; otherwise, false.</returns>
        public static bool ValidCharacter(char character) => character >= 'A' && character <= 'Z';
    }
}
