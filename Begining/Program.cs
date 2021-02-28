using System;
using System.Collections.Generic;

namespace Begining
{
    /// <summary>
    /// Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой клетки в правую нижнюю. 
    /// Известно что ходить можно только на одну клетку вправо или вниз. 
    /// </summary>
    /// 
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
    class Program
    {
        public static int M;
        public static int N;
        
        
        static void Main(string[] args)
        {
            Dictionary<Point, int> cache = new Dictionary<Point, int>();
            Console.WriteLine("Введите размер поля M и N");
            M = int.Parse(Console.ReadLine());
            N = int.Parse(Console.ReadLine());            
            Console.WriteLine($"Количество путей : {GetPath(0, 0, cache)}");
        }

        public static int GetPath(int x, int y, Dictionary<Point, int> cache)
        {
            Point p = new Point(x, y);

            if (cache.ContainsKey(p))
            { 
                return cache[p];
            }

            int xPath = 0;
            int yPath = 0;


            if (x == M - 1 && y == N - 1)
            {
                cache.Add(p, 1);
                return 1;
            }

            if (x < M - 1)
            {
                xPath = GetPath(x + 1, y, cache);
            }

            if (y < N - 1)
            {
                yPath = GetPath(x, y + 1, cache);
            }
            
            cache.Add(p, xPath + yPath); 
            return xPath + yPath;
        } 
    }
}
