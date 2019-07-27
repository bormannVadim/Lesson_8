using System;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {

            // Савенко Вадим

            int[] length = { 1000, 10000,100000 };

            for (int i = 0; i < length.Length; i++)
            {
                DateTime start1 = DateTime.Now;
                int max = 100;
                int[] arr = FillArray(max, length[i]);
                //быстрая сортировка
                FastSort(arr, 0, arr.Length - 1);
                DateTime end1 = DateTime.Now;
                Console.WriteLine("Быстрая сортировка для "+length[i]+" занимает: " + (end1 - start1));
                // сортировка подсчётом df
                start1 = DateTime.Now;
                int[] arr2 = FillArray(max, length[i]);
                countSort(arr2, arr2.Length, max);
                end1 = DateTime.Now;
                Console.WriteLine("Сортировка подсчётом для " + length[i] + " занимает: " + (end1 - start1));
            }
        }
        public static int[] FillArray(int max,int length)
        {
            int[] arr = new int[length];
            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(1, max);
            }
            return arr;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int x in array)
            {
                Console.Write(x + ", ");
            }
            Console.Write("\n");
        }

        public static void countSort(int[] arr, int length,int max)
        {
            int[] newArray = new int[length];
            int[] C = new int[max];
            for (int i = 0; i < max; i++)
                C[i] = 0;
            for (int i = 0; i <length; i++)
                C[arr[i]]++;
           int b = 0;
            for (int j = 0; j < max; j++)
                for (int i = 0; i < C[j] ; i++)
                {
                    arr[b++] = j;
                }
         
        }

        public static void FastSort(int[] arr, int first, int last)
        {
            int p = arr[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i;
                while (arr[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) FastSort(arr, first, j);
            if (i < last) FastSort(arr, i, last);
        }
    }
}
