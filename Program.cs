
using System;
using System.Collections.Generic;
using System.Linq;

class Grandma
{
    public string Name;
    public int Age;
    public List<string> Diseases = new List<string>();
}

class Hospital
{
    public string Name;
    public List<string> Diseases = new List<string>();
    public int Capacity;
    public Stack<Grandma> Patients = new Stack<Grandma>();
}

class Program
{
    static void Main()
    {
        Stack<Hospital> hospitals = new Stack<Hospital>();
        Queue<Grandma> grandmas = new Queue<Grandma>();

        Hospital h1 = new Hospital
        {
            Name = "Больница №1",
            Capacity = 2,
            Diseases = new List<string> { "кашель", "насморк" }
        };

        Hospital h2 = new Hospital
        {
            Name = "Больница №2",
            Capacity = 3,
            Diseases = new List<string> { "голова", "кашель" }
        };

        hospitals.Push(h1);
        hospitals.Push(h2);

        Console.Write("Количество бабуль: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Grandma g = new Grandma();

            Console.Write("Имя: ");
            g.Name = Console.ReadLine();

            Console.Write("Возраст: ");
            g.Age = int.Parse(Console.ReadLine());

            Console.Write("Количество болезней: ");
            int count = int.Parse(Console.ReadLine());

            for (int j = 0; j < count; j++)
            {
                Console.Write("Болезнь: ");
                g.Diseases.Add(Console.ReadLine().ToLower());
            }

            grandmas.Enqueue(g);
        }

        while (grandmas.Count > 0)
        {
            Grandma g = grandmas.Dequeue();
            bool found = false;

            foreach (Hospital h in hospitals)
            {
                int treated = g.Diseases.Count(d =>
                    h.Diseases.Contains(d));

                if (h.Patients.Count < h.Capacity &&
                    (g.Diseases.Count == 0 ||
                    treated * 2 > g.Diseases.Count))
                {
                    h.Patients.Push(g);
                    Console.WriteLine(g.Name + " попала в " + h.Name);
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine(g.Name + " осталась на улице");
        }

        foreach (Hospital h in hospitals)
        {
            Console.WriteLine("\n" + h.Name);
            Console.WriteLine("Пациентов: " + h.Patients.Count);
            Console.WriteLine("Болезни: " + string.Join(", ", h.Diseases));
            Console.WriteLine("Заполненность: " +
                (h.Capacity > 0 ? h.Patients.Count * 100.0 / h.Capacity : 0) + "%");
        }
    }
}
