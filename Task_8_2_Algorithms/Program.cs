using System;
using System.IO;
using System.Collections.Generic;

namespace Task_8_2_Algorithms
{
    /// <summary>
    /// Дописать реализацию Bucketsort до возможности сортировки больших массивов из файла (External sort).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();
            CreateBuckets(filePath);
            BucketSort();
        }

        static void CreateBuckets(string file)
        {
            int bucket_num = 1;

            StreamWriter sw = new StreamWriter(string.Format("C:\\bucket{0:d5}.dat", bucket_num));

            using (StreamReader sr = new StreamReader(file))
            {
                while (sr.Peek() >= 0)
                {                   
                    sw.WriteLine(sr.ReadLine());

                    if (sw.BaseStream.Length > 1000 && sr.Peek() >= 0)
                    {
                        sw.Close();
                        bucket_num++;
                        sw = new StreamWriter(string.Format("C:\\bucket{0:d5}.dat", bucket_num));
                    }
                }
            }

            sw.Close();
        }
        static void BucketSort()
        {
            foreach (string path in Directory.GetFiles("C:\\", "bucket*.dat"))
            {                
                string[] bucketCont = File.ReadAllLines(path);
                
                Array.Sort(bucketCont);
                
                string newpath = path.Replace("bucket", "sorted");
               
                File.WriteAllLines(newpath, bucketCont);
               
                File.Delete(path);
                
                bucketCont = null;

                GC.Collect();
            }
        }

        static void Merge()
        {
            string[] paths = Directory.GetFiles("C:\\", "sorted*.dat");
            int bucketsNumber = paths.Length;
            int records = 1000;
           
            StreamReader[] readers = new StreamReader[bucketsNumber];
            for (int i = 0; i < bucketsNumber; i++)
                readers[i] = new StreamReader(paths[i]);

            StreamWriter sw = new StreamWriter("C:\\MergeSortedFile.txt");
                        
            Queue<string>[] queues = new Queue<string>[bucketsNumber];
            for (int i = 0; i < bucketsNumber; i++)
                queues[i] = new Queue<string>(records);
                        
            for (int i = 0; i < bucketsNumber; i++)
            {
                for (int k = 0; k < records; k++)
                {
                    if (readers[i].Peek() < 0) break;
                    queue.Enqueue(readers[i].ReadLine());
                }
            }           
            
            bool done = false;
            int lowestIndex;
            string lowestValue;

            while (!done)
            {   
                lowest_index = -1;
                lowest_value = "";

                for (j = 0; j < bucketsNumber; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowest_index < 0 || String.CompareOrdinal(queues[j].Peek(), lowest_value) < 0)
                        {
                            lowest_index = j;
                            lowest_value = queues[j].Peek();
                        }
                    }
                }
                
                if (lowest_index == -1) { 
                    done = true; 
                    break; 
                }
                               
                sw.WriteLine(lowest_value);
                
                queues[lowest_index].Dequeue();                
            }

            sw.Close();
            
            for (int i = 0; i < bucketsNumber; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
            }
        }
    }
}
