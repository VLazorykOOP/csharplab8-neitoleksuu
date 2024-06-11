using System;
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

            // Регулярний вираз для видалення однобуквених слів та слів, що починаються з 'a', 'b', 'c', 'd' або 'e'
            string pattern = @"\b\w\b|\b[a-eA-E]\w*\b";
            string resultText = Regex.Replace(inputText, pattern, string.Empty);

            // Видаляємо зайві пробіли, які могли залишитися після видалення слів
            resultText = Regex.Replace(resultText, @"\s+", " ").Trim();

            // Записуємо відредагований текст у новий файл
            File.WriteAllText(outputFilePath, resultText);

            Console.WriteLine("Операція виконана успішно.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
