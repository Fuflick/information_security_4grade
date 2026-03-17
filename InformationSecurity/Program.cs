using System;

class Program
{
    static void Main()
    {
        string text = "Hello, World!";
        string key = "ключ";

        /** Шифрование строки */
        byte[] encrypted = SecondLab.Encrypt(text, key);

        string encryptedBase64 = Convert.ToBase64String(encrypted);
        Console.WriteLine("Зашифрованный текст:");
        Console.WriteLine(encryptedBase64);

        /** Дешифрование строки */
        byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);
        string decrypted = SecondLab.Decrypt(encryptedBytes, key);

        Console.WriteLine("\nРасшифрованный текст:");
        Console.WriteLine(decrypted);

        /** Работа с файлами */
        string inputFile = "input.txt";
        string encryptedFile = "encrypted.bin";
        string decryptedFile = "decrypted.txt";

        /** Шифруем файл */
        SecondLab.EncryptFile(inputFile, encryptedFile, key);
        Console.WriteLine("\nФайл зашифрован");

        /** Дешифруем файл */
        SecondLab.DecryptFile(encryptedFile, decryptedFile, key);
        Console.WriteLine("Файл расшифрован");
    }
}