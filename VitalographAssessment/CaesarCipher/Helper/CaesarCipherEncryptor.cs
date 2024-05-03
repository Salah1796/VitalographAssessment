using System.Text;
using VitalographAssessment.Helper.Interfaces;

namespace VitalographAssessment.Helper
{
    /// <summary>
    /// Provides methods for encrypting messages using the Caesar cipher algorithm.
    /// </summary>
    public class CaesarCipherEncryptor : ICaesarCipherEncryptor
    {
        public string Encrypt(string input, int shift)
        {
            if (string.IsNullOrEmpty(input) || shift == 0)
                return input;
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


        public bool ValidCharacter(char character) => character >= 'A' && character <= 'Z';
    }
}
