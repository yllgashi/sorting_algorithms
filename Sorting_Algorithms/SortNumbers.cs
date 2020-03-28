using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    class SortNumbers
    {
        public void CreateArray()
        {
            Console.Write("Size of your array: ");
            int arraySize = int.Parse(Console.ReadLine());
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Element {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Choose(array);
        }

        public void Choose(int[] array)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWhich sort do you want to use");
                Console.WriteLine("1. Show your array");
                Console.WriteLine("2. Selection Sort");
                Console.WriteLine("3. Bubble Sort");
                Console.WriteLine("4. Insertion Sort");
                Console.WriteLine("5. Insertion Sort (combination of sequential and binary search)");
                Console.WriteLine("6. Quit");
                Console.Write("\n Enter your number: ");
                Console.ForegroundColor = ConsoleColor.White;
                int answer = int.Parse(Console.ReadLine());

                if (answer == 1)
                {
                    ShowArray(array);
                }
                else if (answer == 2)
                {
                    SelectionSort(array);
                    Console.WriteLine("Array has been sorted");
                }
                else if (answer == 3)
                {
                    BubbleSort(array);
                    Console.WriteLine("Array has been sorted");
                }
                else if (answer == 4)
                {
                    InsertionSort(array);
                    Console.WriteLine("Array has been sorted");
                }
                else if (answer == 5)
                {
                    SequentialAndBinaryInsert(array);
                    Console.WriteLine("Array has been sorted");
                }
                else if (answer == 6)
                {
                    break;
                }
            }
        }

        public void BubbleSort(int[] array)
        {
            Console.Clear();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    while (true)
                    {
                        if (array[j + 1] < array[j])
                        {
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                        break;
                    }
                }
            }

        }

        public void SelectionSort(int[] array)
        {
            Console.Clear();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        /////// Shto edhe mundesine kombinim binar me sekuencial

        public void InsertionSort(int[] array)
        {
            Console.Clear();
            char answer;
            Console.Write("Do you want to implement binary search? (y/n): ");
            while (true)
            {
                answer = char.Parse(Console.ReadLine());
                if (answer == 'y')
                {
                    Console.WriteLine();
                    Console.WriteLine("Good choice !");
                    Console.WriteLine();
                    BinarySearchSort(array);
                    break;
                }
                else if (answer == 'n')
                {
                    Console.WriteLine();
                    Console.WriteLine("Slower, but it works great!");
                    Console.WriteLine();
                    Console.Write("");
                    SequentialInsert(array);
                    break;
                }
                else
                {
                    Console.Write("Wrong character, try again (y/n): ");
                }
            }
        }

        public void SequentialInsert(int[] array)
        {
            Console.Clear();
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void SequentialAndBinaryInsert(int[] array)
        {
            Console.Clear();
            for (int i = 1; i < array.Length; i++)
            {
                while (true)
                {
                    int middle = i / 2;
                    if (array[i] < array[middle])
                    {
                        for (int j = i; j > 0; j--)
                        {
                            if (array[j] < array[j - 1])
                            {
                                int temp = array[j - 1];
                                array[j - 1] = array[j];
                                array[j] = temp;
                            }
                        }
                    }
                    else if (array[i] <= array[i - 1])
                    {
                        for (int j = i; j >= middle; j--)
                        {
                            if (array[j] < array[j - 1])
                            {
                                int temp = array[j - 1];
                                array[j - 1] = array[j];
                                array[j] = temp;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void BinarySearchSort(int[] array)
        {
            Console.Clear();
            for (int i = 1; i < array.Length; i++)
            {
                int max = i;
                int min = 0;

                while (true)
                {
                    int middle = (min + max) / 2;

                    if (array[i] < array[i - 1])
                    {
                        if (middle == 0 && array[i] < array[middle])
                        {
                            MoveForwardElementOfArray(array, middle, i);
                            break;
                        }
                        else if (middle != 0 && array[i] < array[middle] && array[i] > array[middle - 1])
                        {
                            MoveForwardElementOfArray(array, middle, i);
                            break;
                        }

                        else if (middle != 0 && array[i] <= array[middle - 1] && array[i] > array[middle])
                        {
                            MoveForwardElementOfArray(array, (middle - 1), i);
                            break;
                        }
                        else if (middle != 0 && array[i] <= array[middle + 1] && array[i] > array[middle])
                        {
                            MoveForwardElementOfArray(array, (middle + 1), i);
                            break;
                        }

                        else if (array[i] == array[middle])
                        {
                            MoveForwardElementOfArray(array, middle, i);
                        }
                        else if (array[i] < array[middle])
                        {
                            min = 0;
                            max = middle;
                            continue;
                        }
                        else if (array[i] > array[middle])
                        {
                            min = middle;
                            max = i;
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }

        public void MoveForwardElementOfArray(int[] array, int middle, int sortingElement)
        {
            for (int i = sortingElement; i > middle; i--)
            {
                int temp = array[i - 1];
                array[i - 1] = array[i];
                array[i] = temp;
            }
        }

        public void ShowArray(int[] array)
        {
            Console.WriteLine("#########################");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
