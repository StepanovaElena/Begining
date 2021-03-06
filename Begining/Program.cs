using System;
using System.Collections.Generic;

namespace Begining
{
    /// <summary>
    /// 1. Bucketsort Реализовать Bucketsort, проверить корректность работы.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new int[15];
            Random rnd = new Random();

            for (int i = 0; i < integers.Length; ++i)
                integers[i] = rnd.Next(-99, 100);

            Console.WriteLine(String.Join(" ", integers));
            BucketSort(integers);
            Console.WriteLine(String.Join(" ", integers));

        }

        private static void BucketSort(int[] integers)
        {            
            if (integers == null || integers.Length == 0)
                return;
            
            int maxValue = integers[0]; 
            int minValue = integers[0];
            
            for (int i = 1; i < integers.Length; i++)
            {
                if (integers[i] > maxValue)
                    maxValue = integers[i];

                if (integers[i] < minValue)
                    minValue = integers[i];
            }

            List<int>[] buckets = new List<int>[integers.Length];
            int bucketLength = 10;
            int numRange = maxValue - minValue;

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }            

            for (int i = 0; i < integers.Length; ++i) {
                
                int bucketIdx = (int)Math.Floor((double)(integers[i] - minValue) / numRange * bucketLength);
                buckets[bucketIdx].Add(integers[i]);
            }
            
            for (int i = 0; i < buckets.Length; ++i)
            {
                InsertionSort(buckets[i]);
            }
                
            //Move items in the bucket back to the original array in order
            int k = 0; 
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i].Count > 0)
                {
                    for (int j = 0; j < buckets[i].Count; j++)
                    {
                        integers[k] = buckets[i][j];
                        k++;
                    }
                }
            }
        }

        public static List<int> InsertionSort(List<int> bucket)
        {
            for (int i = 1; i < bucket.Count; i++)
            {                
                int currentValue = bucket[i];
                int pointer = i - 1;
                
                while (pointer >= 0)
                {                    
                    if (currentValue < bucket[pointer])
                    {                        
                        bucket[pointer + 1] = bucket[pointer];
                        bucket[pointer] = currentValue;
                    }
                    else break;
                }
            }

            return bucket;
        }
    }
}
