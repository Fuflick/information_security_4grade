using System;
using System.IO;
using System.Text;

public class SecondLab
{
    public static byte[] Encrypt(string text, string key)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] result = new byte[textBytes.Length];

        for (int i = 0; i < textBytes.Length; i++)
        {
            byte k = keyBytes[i % keyBytes.Length];
            result[i] = (byte)((textBytes[i] + k) % 256);
        }

        return result;
    }

    public static string Decrypt(byte[] cipherBytes, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] result = new byte[cipherBytes.Length];

        for (int i = 0; i < cipherBytes.Length; i++)
        {
            byte k = keyBytes[i % keyBytes.Length];
            result[i] = (byte)((256 + cipherBytes[i] - k) % 256);
        }

        return Encoding.UTF8.GetString(result);
    }

    public static void EncryptFile(string inputPath, string outputPath, string key)
    {
        byte[] fileBytes = File.ReadAllBytes(inputPath);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] result = new byte[fileBytes.Length];

        for (int i = 0; i < fileBytes.Length; i++)
        {
            byte k = keyBytes[i % keyBytes.Length];
            result[i] = (byte)((fileBytes[i] + k) % 256);
        }

        File.WriteAllBytes(outputPath, result);
    }

    public static void DecryptFile(string inputPath, string outputPath, string key)
    {
        byte[] fileBytes = File.ReadAllBytes(inputPath);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] result = new byte[fileBytes.Length];

        for (int i = 0; i < fileBytes.Length; i++)
        {
            byte k = keyBytes[i % keyBytes.Length];
            result[i] = (byte)((256 + fileBytes[i] - k) % 256);
        }

        File.WriteAllBytes(outputPath, result);
    }
}