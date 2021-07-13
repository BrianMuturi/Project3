using System;
using System.Diagnostics;
using System.Threading;

namespace Project3
{
    class Program
    {
        static void Main(string[] args)
        {

            //Initialization
            int Min = 0;
            int Max = 100;
            int[] arr = new int[10];

            //Random Array generation
            Random randNum = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(Min, Max);
            }

            //Print original array
            int[] temp = arr;
            Console.Write("Original Array: ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // reverse the array
            Array.Reverse(temp);
            Console.Write("Reversed Array: ");
            foreach (int i in temp)
            {
                Console.Write(i + " ");
            }

            //Insertion sort
            InsertionSort ob = new InsertionSort();
            ob.sort(arr);
            printArray(arr);

            //MergeSort Sort
            MergeSort mg = new MergeSort();
            mg.sort(arr, 0, arr.Length - 1);
            printmergedArray(arr);

            //Counting Sort
            CountingSort cs = new CountingSort();
            Console.Write("\nCounting Sort Array:");
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + " ");

            Console.ReadLine();
        }

       

        private static void printmergedArray(int[] arr)
        {
            int n = arr.Length;
            Console.Write("Merged Array:");
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arr[i] + " ");
            }
        }

        private static void printArray(int[] arr)
        {

            int n = arr.Length;
            Console.Write("\nInserted Array: ");
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");

        }
    }
    //Insertion Sort
    public class InsertionSort
    {
        public void sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }

        }
    }
    //Merge Sort
    public class MergeSort
    {
        void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];

            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        internal void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                sort(arr, l, m);
                sort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
        }

    }
    public class CountingSort
    {
        private static void countsort(int[] arr)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[256];
            for (int i = 0; i < 256; ++i)
                count[i] = 0;
            for (int i = 0; i < n; ++i)
                ++count[arr[i]];
            for (int i = 1; i <= 255; ++i)
                count[i] += count[i - 1];
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                --count[arr[i]];
            }

            for (int i = 0; i < n; ++i)
                arr[i] = output[i];
        }
    }
}