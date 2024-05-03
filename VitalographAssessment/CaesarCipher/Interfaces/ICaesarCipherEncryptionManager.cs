namespace VitalographAssessment.Interfaces
{
    public interface ICaesarCipherEncryptionManager
    {
        int DefaultShift { get; }
        string ExitCommand { get; }
        string ContinueCommand { get; }

        /// <summary>
        /// Run Caesar Cipher Encryption Manager
        /// </summary>
        void Run();
    }
}