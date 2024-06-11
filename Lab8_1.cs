using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Шлях до вхідного файлу
        string inputFilePath = @"C:\Users\foolm\OneDrive\Робочий стіл\input.txt"; // Замініть на актуальний шлях до вашого файлу
        // Шлях до вихідного файлу
        string outputFilePath = @"C:\Users\foolm\OneDrive\Робочий стіл\output.txt";

        // Зчитуємо вміст вхідного файлу
        string inputText = File.ReadAllText(inputFilePath);

        // Регулярний вираз для пошуку IP-адрес у форматі d.d.d.d, де d - ціле шістнадцяткове число
        string pattern = @"\b([0-9A-Fa-f]{1,2}\.){3}[0-9A-Fa-f]{1,2}\b";
        Regex regex = new Regex(pattern);

        // Знаходимо всі IP-адреси у тексті
        MatchCollection matches = regex.Matches(inputText);
        List<string> ipAddresses = matches.Cast<Match>().Select(m => m.Value).ToList();

        // Записуємо знайдені IP-адреси у вихідний файл
        File.WriteAllLines(outputFilePath, ipAddresses);

        // Виводимо кількість знайдених IP-адрес
        Console.WriteLine($"Found {ipAddresses.Count} IP addresses.");

        // Заміна IP-адрес за вказаними параметрами користувача
        Console.WriteLine("Enter the IP address to replace:");
        string ipToReplace = Console.ReadLine();
        Console.WriteLine("Enter the new IP address:");
        string newIp = Console.ReadLine();

        // Перевірка, чи є IP-адреса у списку
        if (ipAddresses.Contains(ipToReplace))
        {
            inputText = inputText.Replace(ipToReplace, newIp);
            Console.WriteLine($"Replaced {ipToReplace} with {newIp}.");
        }
        else
        {
            Console.WriteLine($"{ipToReplace} not found in the text.");
        }

        // Записуємо оновлений текст у новий файл у робочу директорію проекту
        string updatedFileName = "updated_input.txt";
        File.WriteAllText(updatedFileName, inputText);
    }
}
