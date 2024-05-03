  # Caesar Cipher Encryption
  
  ## Overview
  
  Caesar Cipher Encryption is a simple encryption program based on the Caesar cipher algorithm. It takes a message and a shift value as input and encrypts the message using the provided shift value. The Caesar cipher algorithm shifts each letter in the message by a certain number of positions down the alphabet.
  
  ## Features
  
  - Encrypts messages using the Caesar cipher algorithm.
  - Allows users to specify the shift value for encryption.
  - Provides a default shift value if no shift value is provided.
  - Handles input validation to ensure that only valid characters and inputs are accepted.
  
  ## Usage
  
  To use the Caesar Cipher Encryption program, follow these steps:
  
  1. Clone the repository to your local machine.
  2. Navigate to the project directory.
  3. Build the project using your preferred build tool.
  4. Run the program.
  5. Enter a message to encrypt containing characters between A-Z. Type 'exit' to close the program.
  6. Enter the shift value for encryption. Press Enter to use the default shift value.
  7. View the encrypted output.
  8. Choose whether to continue encrypting more messages or exit the program.
  
  ## Examples
  
  Here are some examples of using the Caesar Cipher Encryption program:
  
  - **Example 1:**
    ```plaintext
    Enter a message to encrypt containing characters between A-Z (type 'exit' to close):
    > HELLO
    Enter the shift value (Click 'Enter' to use default 5):
    > 3
    Output: KHOOR
    Do you want to continue (Y/N)? N
    Exiting program...
  
  - **Example 2**
   ```plaintext
  Enter a message to encrypt containing characters between A-Z (type 'exit' to close):
  > GOODBYE
  Enter the shift value (Click 'Enter' to use default 5):
  > 7
  Output: NVVKLFL
  Do you want to continue (Y/N)? Y
  Enter a message to encrypt containing characters between A-Z (type 'exit' to close):
  > WELCOME
  Enter the shift value (Click 'Enter' to use default 5):
  > 10
  Output: GOVMYWO
  Do you want to continue (Y/N)? N
  Exiting program...
  
  
  
  ## Testing
  
  The project includes unit tests written using the xUnit testing framework to ensure the correctness of the encryption algorithm and program logic.
  Integration tests are also provided to test the functionality of the `Run` method.
  
  
