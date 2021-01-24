using System;

namespace Task_2_2_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = new int[] { 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4 };
            //int[] array = new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            int[] array = new int[] { 4, 4 };  
            Array.Sort(array);

            int result = BinarySearch(array, 4);               
            
            Console.WriteLine($"The desired value is present {result} times");
        }

        static public int BinarySearch(int[] inputArray, int searchValue)
        {
            int left = 0;
            int right = inputArray.Length - 1;
            int n = 0;

            if(inputArray.Length < 2 && inputArray[0] == searchValue)
            {
                return 1;
            }

            while (left < right)
            {
                int mid = (left + right) / 2; // поиск до того пока 1 = N / 2^x, 2 x = N , приводя к логорифму x = log2(N), те O(log(N))
                if (searchValue != inputArray[mid])
                {
                    if (inputArray[left] < inputArray[mid]) {
                        _ = (searchValue >= inputArray[left]) && (searchValue < inputArray[mid]) ? right = mid - 1 : left = mid + 1;
                    }

                    if(inputArray[mid] < inputArray[right]) {
                        _ = (searchValue > inputArray[mid] && searchValue <= inputArray[right]) ? left = mid + 1 : right = mid - 1;
                    }
                }
                
                else
                {
                    n += 1;
                    if (inputArray[left] == inputArray[mid])
                    {
                        n += mid - left;
                        left = mid + 1;
                    }

                    if (inputArray[right] == inputArray[mid]) {
                        n += right - mid;
                        right = mid - 1;
                    }
                } 
            }

            return n;
        }
    }
}
