using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static readonly Random Rnd = new Random();

    static void Main()
    {
        
        string dir = Path.Combine(Directory.GetCurrentDirectory(), "images");
        string[] images = Enumerable.Range(1, 32)
            .Select(i => Path.Combine(dir, $"{i}.png"))
            .ToArray();

        
        foreach (var img in images)
            if (!File.Exists(img))
                throw new FileNotFoundException($"Не найден файл: {img}");

        
        var original = new List<string>();
        foreach (var img in images)
        {
            original.Add(img);
            original.Add(img);
        }

        var shuffled = new List<string>(original);
        Shuffle(shuffled);

        
        Console.WriteLine("ИЗНАЧАЛЬНЫЙ LIST");
        PrintList(original);

        Console.WriteLine("\nПОЛУЧЕННЫЙ LIST");
        PrintList(shuffled);

        
        Console.WriteLine($"\nРазмер списка: {shuffled.Count}");
        Console.WriteLine($"Каждая картинка ровно 2 раза: " +
            $"{shuffled.GroupBy(x => x).All(g => g.Count() == 2)}");
    }

    
    static void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Rnd.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    
    static void PrintList(List<string> list)
    {
        for (int i = 0; i < list.Count; i += 8)
        {
            var chunk = Enumerable.Range(i, Math.Min(8, list.Count - i))
                .Select(j => $"{j,2}:{Path.GetFileNameWithoutExtension(list[j]),2}");
            Console.WriteLine(string.Join("  ", chunk));
        }
    }
}