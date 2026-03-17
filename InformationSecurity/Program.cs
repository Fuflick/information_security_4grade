class Program
{
    static void Main()
    {
        // === СТРОКА ===
        string text = "Hello, World!";
        string key = "key";

        string encrypted = ThirdLab.EncryptString(text, key);
        string decrypted = ThirdLab.DecryptString(encrypted, key);

        Console.WriteLine("Исходный: " + text);
        Console.WriteLine("Зашифрованный: " + encrypted);
        Console.WriteLine("Расшифрованный: " + decrypted);

        // === ФАЙЛ ===
        string inputFile = "input.txt";
        string encryptedFile = "encrypted.bin";
        string decryptedFile = "decrypted.txt";

        // создадим тестовый файл
        File.WriteAllText(inputFile, "Пример текста для файла");

        ThirdLab.EncryptFile(inputFile, encryptedFile, key);
        ThirdLab.DecryptFile(encryptedFile, decryptedFile, key);

        Console.WriteLine("\nФайл зашифрован и расшифрован.");
    }
}