using System;
using System.IO;
using System.Text;

class ThirdLab
{
    /** ШИФРОВАНИЕ / ДЕШИФРОВАНИЕ (один и тот же метод) */
    public static byte[] ApplyGamma(byte[] data, byte[] key)
    {
        byte[] result = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            result[i] = (byte)(data[i] ^ key[i % key.Length]);
        }

        return result;
    }

    /** СТРОКИ */
    public static string EncryptString(string text, string key)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] encrypted = ApplyGamma(textBytes, keyBytes);

        return Convert.ToBase64String(encrypted); // удобно выводить
    }

    public static string DecryptString(string encryptedText, string key)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] decrypted = ApplyGamma(encryptedBytes, keyBytes);

        return Encoding.UTF8.GetString(decrypted);
    }

    /** ФАЙЛЫ */
    public static void EncryptFile(string inputPath, string outputPath, string key)
    {
        byte[] fileBytes = File.ReadAllBytes(inputPath);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] encrypted = ApplyGamma(fileBytes, keyBytes);

        File.WriteAllBytes(outputPath, encrypted);
    }

    public static void DecryptFile(string inputPath, string outputPath, string key)
    {
        EncryptFile(inputPath, outputPath, key);
    }
}