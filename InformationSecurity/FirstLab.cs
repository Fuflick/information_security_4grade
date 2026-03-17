using System;
using System.IO.Pipelines;
using System.Runtime.Serialization.Formatters;

namespace InformationSecurity
{
  class FirstLab
  {
    static int[] GetColumnOrder(string key)
    {
      var pairs = key
        .Select((ch, index) => new { ch, index })
        .OrderBy(x => x.ch)
        .ThenBy(x => x.index)
        .ToArray();

      var order = new int[key.Length];

      for (int i = 0; i < pairs.Length; i++)
        order[pairs[i].index] = i;

      return order;
    }

    public static string Encrypt(string input, string key)
    {
      input = input.Replace(" ", "");

      int cols = key.Length;
      int rows = (input.Length + cols - 1) / cols;

      char[,] matrix = new char[rows, cols];

      int index = 0;
      for (int r = 0; r < rows; r++)
      {
        for (int c = 0; c < cols; c++)
        {
          matrix[r, c] = index < input.Length ? input[index++] : ' ';
        }
      }

      int[] order = GetColumnOrder(key);

      var result = new System.Text.StringBuilder();

      for (int k = 0; k < cols; k++)
      {
        int col = Array.IndexOf(order, k);

        for (int r = 0; r < rows; r++)
          result.Append(matrix[r, col]);
      }

      return result.ToString();
    }

    public static string Decrypt(string cipher, string key)
    {
      int cols = key.Length;
      int rows = (cipher.Length + cols - 1) / cols;

      char[,] matrix = new char[rows, cols];

      int[] order = GetColumnOrder(key);

      int index = 0;

      for (int k = 0; k < cols; k++)
      {
        int col = Array.IndexOf(order, k);

        for (int r = 0; r < rows; r++)
        {
          if (index < cipher.Length)
            matrix[r, col] = cipher[index++];
        }
      }

      var result = new System.Text.StringBuilder();

      for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
          result.Append(matrix[r, c]);

      return result.ToString().TrimEnd();
    }
  }

  /** Пример использования */
  
  // string text = "ЭТО СООБЩЕНИЕ СЛЕДУЕТ ОТПРАВИТЬ";
  // string key = "КОМБАЙН";

  // var enc = FirstLab.Encrypt(text, key);
  // Console.WriteLine(enc);

  // var dec = FirstLab.Decrypt(enc, key);
  // Console.WriteLine(dec);
}