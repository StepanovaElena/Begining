using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;

namespace Begining
{    
    public class PointClass
    {
        public int X;
        public int Y;
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
    }

    public class BechmarkClass
    {
        public static List<PointClass> pointsClass = new List<PointClass>();
        public static List<PointStruct> pointsStruct = new List<PointStruct>();

        public BechmarkClass()
        {
            SetPoint();
        }

        public float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        public PointClass GetPointClass()
        {
            Random rnd = new Random();
            PointClass value = pointsClass[rnd.Next(0, 10000)];
            return value;
        }

        public PointStruct GetPointStruct()
        {
            Random rnd = new Random();
            PointStruct value = pointsStruct[rnd.Next(0, 10000)];
            return value;
        }


        public static void SetPoint()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                pointsClass.Add(new PointClass {
                    X = rnd.Next(0, 200),
                    Y = rnd.Next(0, 200)
                });

                pointsStruct.Add(new PointStruct
                {
                    X = rnd.Next(0, 200),
                    Y = rnd.Next(0, 200)
                });
            }
        }

        [Benchmark]
        public void TestPointDistance()
        {
            PointStruct pointOne = GetPointStruct();
            PointStruct pointTwo = GetPointStruct();
            PointDistance(pointOne, pointTwo);            
        }

        [Benchmark]
        public void TestPointDistanceDouble()
        {
            PointStruct pointOne = GetPointStruct();
            PointStruct pointTwo = GetPointStruct();
            PointDistanceDouble(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceShort()
        {
            PointStruct pointOne = GetPointStruct();
            PointStruct pointTwo = GetPointStruct();
            PointDistanceShort(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceWithClass()
        {
            PointClass pointOne = GetPointClass();
            PointClass pointTwo = GetPointClass();
            PointDistance(pointOne, pointTwo);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
