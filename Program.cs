
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Surname, Name, Exam;
    public int Year, Score;

    public override string ToString()
    {
        return $"{Surname} {Name}, {Year}, {Exam}, {Score}";
    }
}

class Program
{
    static List<Student> students = new List<Student>();
    static string file = "students.txt";

    static void Main()
    {
        if (File.Exists(file))
        {
            foreach (string line in File.ReadAllLines(file))
            {
                string[] d = line.Split(';');
                students.Add(new Student
                {
                    Surname = d[0],
                    Name = d[1],
                    Year = int.Parse(d[2]),
                    Exam = d[3],
                    Score = int.Parse(d[4])
                });
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
                students.Add(new Student
                {
                    Surname = "Студент" + i,
                    Name = "Имя" + i,
                    Year = 2007,
                    Exam = "Математика",
                    Score = 60 + i
                });
        }

        while (true)
        {
            Console.WriteLine("\nНовый студент / Удалить / Сортировать / Показать / Выход");
            string cmd = Console.ReadLine().ToLower();

            if (cmd == "новый студент")
            {
                Student s = new Student();

                Console.Write("Фамилия: ");
                s.Surname = Console.ReadLine();
                Console.Write("Имя: ");
                s.Name = Console.ReadLine();
                Console.Write("Год рождения: ");
                s.Year = int.Parse(Console.ReadLine());
                Console.Write("Экзамен: ");
                s.Exam = Console.ReadLine();
                Console.Write("Баллы: ");
                s.Score = int.Parse(Console.ReadLine());

                students.Add(s);
            }
            else if (cmd == "удалить")
            {
                Console.Write("Фамилия: ");
                string surname = Console.ReadLine();
                Console.Write("Имя: ");
                string name = Console.ReadLine();

                Student s = students.FirstOrDefault(x => x.Surname == surname && x.Name == name);

                if (s != null) students.Remove(s);
                else Console.WriteLine("Не найден");
            }
            else if (cmd == "сортировать")
                students = students.OrderBy(x => x.Score).ToList();

            else if (cmd == "показать")
                foreach (Student s in students)
                    Console.WriteLine(s);

            else if (cmd == "выход")
                break;
            else
                Console.WriteLine("Неизвестная команда");

            File.WriteAllLines(file, students.Select(s =>
                $"{s.Surname};{s.Name};{s.Year};{s.Exam};{s.Score}"));
        }
    }
}
