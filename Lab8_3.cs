using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Шлях до вхідного файлу
        string inputFilePath = @"C:\Users\foolm\OneDrive\Робочий стіл\input.txt"; // Замініть на актуальний шлях до вашого файлу
        // Шлях до вихідного файлу
        string outputFilePath = @"C:\Users\foolm\OneDrive\Робочий стіл\output.txt";

        try
        {
            // Зчитуємо вміст вхідного файлу
            string inputText = File.ReadAllText(inputFilePath);

            // Розбиваємо текст на слова, враховуючи пробіли та розділові знаки
            string[] words = Regex.Split(inputText, @"\W+");

            // Список для збереження симетричних слів
            List<string> symmetricWords = new List<string>();

            // Перевіряємо кожне слово на симетричність
            foreach (string word in words)
            {
                if (IsSymmetric(word))
                {
                    symmetricWords.Add(word);
                }
            }

            // Записуємо симетричні слова у вихідний файл
            File.WriteAllLines(outputFilePath, symmetricWords);

            Console.WriteLine("Операція виконана успішно.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    // Метод для перевірки слова на симетричність
    static bool IsSymmetric(string word)
    {
        int length = word.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (word[i] != word[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}
