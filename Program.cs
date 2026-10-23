
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] graph =
        {
            { 0, 1, 1, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 1 },
            { 0, 1, 1, 0, 1 },
            { 0, 0, 1, 1, 0 }
        };

        Console.Write("Начальная вершина (0-4): ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("Конечная вершина (0-4): ");
        int end = int.Parse(Console.ReadLine());

        Queue<int> queue = new Queue<int>();
        int[] parent = new int[5];
        bool[] visited = new bool[5];

        Array.Fill(parent, -1);
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int v = queue.Dequeue();

            if (v == end)
                break;

            for (int i = 0; i < 5; i++)
            {
                if (graph[v, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    parent[i] = v;
                    queue.Enqueue(i);
                }
            }
        }

        if (!visited[end])
        {
            Console.WriteLine("Путь не найден");
            return;
        }

        List<int> path = new List<int>();

        for (int v = end; v != -1; v = parent[v])
            path.Add(v);

        path.Reverse();

        Console.WriteLine("Кратчайший путь: " +
            string.Join(" -> ", path));
    }
}
