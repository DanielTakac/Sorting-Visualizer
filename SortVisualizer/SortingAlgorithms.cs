using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms {

    public class SortingAlgorithms {

        public static int[] InsertionSort(int[] input, out long time) {

            var sw = new Stopwatch();

            sw.Start();

            int[] referenceArray = new int[input.Length];
            int[] sortedArray = new int[input.Length];

            Array.Copy(input, referenceArray, input.Length);
            Array.Copy(input, sortedArray, input.Length);
            Array.Sort(referenceArray);

            for (int i = 1; i < sortedArray.Length; i++) {

                int j = i;

                while (j > 0 && sortedArray[j - 1] > sortedArray[j]) {

                    (sortedArray[j], sortedArray[j - 1]) = (sortedArray[j - 1], sortedArray[j]);

                    j--;

                }


            }

            sw.Stop();

            Console.WriteLine($"InsertionSort: {sw.ElapsedMilliseconds} ms\n");

            time = sw.ElapsedMilliseconds;

            return sortedArray;

        }

        public static int[] SelectionSort(int[] input, out long time) {

            var sw = new Stopwatch();

            sw.Start();

            int[] referenceArray = new int[input.Length];
            int[] sortedArray = new int[input.Length];

            Array.Copy(input, referenceArray, input.Length);
            Array.Copy(input, sortedArray, input.Length);
            Array.Sort(referenceArray);

            for (int i = 0; i < sortedArray.Length - 1; i++) {

                int min = i;

                for (int j = i + 1; j < sortedArray.Length; j++) {

                    if (sortedArray[j] < sortedArray[min]) {

                        min = j;

                    }

                }

                if (min != i) {

                    (sortedArray[i], sortedArray[min]) = (sortedArray[min], sortedArray[i]);

                }


            }

            sw.Stop();

            Console.WriteLine($"SelectionSort: {sw.ElapsedMilliseconds} ms\n");

            time = sw.ElapsedMilliseconds;

            return sortedArray;

        }

        public static int[] QuickSort(int[] input, out long time) {

            var sw = new Stopwatch();

            sw.Start();

            int[] referenceArray = new int[input.Length];
            int[] sortedArray = new int[input.Length];

            Array.Copy(input, referenceArray, input.Length);
            Array.Copy(input, sortedArray, input.Length);
            Array.Sort(referenceArray);

            int[] QuickSort(int[] array, int left, int right) {

                if (left < right) {

                    int pivot = Partition(array, left, right);

                    if (pivot > 1) {

                        QuickSort(array, left, pivot - 1);

                    }

                    if (pivot + 1 < right) {

                        QuickSort(array, pivot + 1, right);

                    }

                }

                return array;

            }

            int Partition(int[] array, int left, int right) {

                int pivot = array[left];

                while (true) {

                    while (array[left] < pivot) {

                        left++;

                    }

                    while (array[right] > pivot) {

                        right--;

                    }

                    if (left < right) {

                        if (array[left] == array[right])
                            return right;

                        (array[left], array[right]) = (array[right], array[left]);

                    } else {

                        return right;

                    }

                }

            }

            QuickSort(sortedArray, 0, sortedArray.Length - 1);

            sw.Stop();

            Console.WriteLine($"QuickSort: {sw.ElapsedMilliseconds} ms\n");

            time = sw.ElapsedMilliseconds;

            return sortedArray;

        }

        public static int[] MergeSort(int[] input, out long time) {

            var sw = new Stopwatch();

            sw.Start();

            int[] referenceArray = new int[input.Length];
            int[] sortedArray = new int[input.Length];

            Array.Copy(input, referenceArray, input.Length);
            Array.Copy(input, sortedArray, input.Length);
            Array.Sort(referenceArray);

            int[] MergeSort(int[] array) {

                if (array.Length <= 1)
                    return array;

                int mid = array.Length / 2;

                int[] left = new int[mid];
                int[] right = new int[array.Length - mid];

                Array.Copy(array, 0, left, 0, mid);
                Array.Copy(array, mid, right, 0, array.Length - mid);

                left = MergeSort(left);
                right = MergeSort(right);

                return Merge(left, right);

            }

            int[] Merge(int[] left, int[] right) {

                int[] result = new int[left.Length + right.Length];

                int index = 0;
                int leftIndex = 0;
                int rightIndex = 0;

                while (leftIndex < left.Length || rightIndex < right.Length) {

                    if (leftIndex < left.Length && rightIndex < right.Length) {

                        if (left[leftIndex] <= right[rightIndex]) {

                            result[index] = left[leftIndex];
                            leftIndex++;

                        } else {

                            result[index] = right[rightIndex];
                            rightIndex++;

                        }

                    } else if (leftIndex < left.Length) {

                        result[index] = left[leftIndex];
                        leftIndex++;

                    } else if (rightIndex < right.Length) {

                        result[index] = right[rightIndex];
                        rightIndex++;

                    }

                    index++;

                }

                return result;

            }

            sortedArray = MergeSort(sortedArray);

            sw.Stop();

            Console.WriteLine($"MergeSort: {sw.ElapsedMilliseconds} ms\n");

            time = sw.ElapsedMilliseconds;

            return sortedArray;

        }

        public static int[] HeapSort(int[] input, out long time) {

            var sw = new Stopwatch();

            sw.Start();

            int[] referenceArray = new int[input.Length];
            int[] sortedArray = new int[input.Length];

            Array.Copy(input, referenceArray, input.Length);
            Array.Copy(input, sortedArray, input.Length);
            Array.Sort(referenceArray);

            int[] HeapSort(int[] array) {

                int heapSize = array.Length;

                for (int i = heapSize / 2 - 1; i >= 0; i--) {

                    Heapify(array, heapSize, i);

                }

                for (int i = array.Length - 1; i >= 0; i--) {

                    (array[0], array[i]) = (array[i], array[0]);

                    heapSize--;

                    Heapify(array, heapSize, 0);

                }

                return array;

            }

            void Heapify(int[] array, int heapSize, int index) {

                int largest = index;
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                if (left < heapSize && array[left] > array[largest]) {

                    largest = left;

                }

                if (right < heapSize && array[right] > array[largest]) {

                    largest = right;

                }

                if (largest != index) {

                    (array[index], array[largest]) = (array[largest], array[index]);

                    Heapify(array, heapSize, largest);

                }

            }

            sortedArray = HeapSort(sortedArray);

            sw.Stop();

            Console.WriteLine($"HeapSort: {sw.ElapsedMilliseconds} ms\n");

            time = sw.ElapsedMilliseconds;

            return sortedArray;

        }

        public static int[] BubbleSort(int[] input, out long time) {

            var sw = new Stopwatch();

            sw.Start();

            int[] referenceArray = new int[input.Length];
            int[] sortedArray = new int[input.Length];

            Array.Copy(input, referenceArray, input.Length);
            Array.Copy(input, sortedArray, input.Length);
            Array.Sort(referenceArray);

            while (!sortedArray.SequenceEqual(referenceArray)) {

                for (int i = 1; i < sortedArray.Length; i++) {

                    if (sortedArray[i - 1] > sortedArray[i]) {

                        // Console.WriteLine($"Swapped {sortedArray[i - 1]} with {sortedArray[i]} at position {i - 1}");

                        (sortedArray[i - 1], sortedArray[i]) = (sortedArray[i], sortedArray[i - 1]);

                    } else {

                        // Console.WriteLine($"Didn't swap {sortedArray[i - 1]} with {sortedArray[i]} at position {i - 1}");

                    }

                }

            }

            sw.Stop();

            Console.WriteLine($"BubbleSort: {sw.ElapsedMilliseconds} ms\n");

            time = sw.ElapsedMilliseconds;

            return sortedArray;

        }

        public static int[] BogoSort(int[] input, out long time) {

            int[] referenceArray = new int[input.Length];

            Array.Copy(input, referenceArray, input.Length);
            Array.Sort(referenceArray);

            int[] sortedArray = new int[input.Length];

            var sw = new Stopwatch();

            sw.Start();

            while (!sortedArray.SequenceEqual(referenceArray)) {

                var random = new Random();

                sortedArray = input.OrderBy(x => random.Next()).ToArray();

            }

            sw.Stop();

            Console.WriteLine($"BogoSort: {sw.ElapsedMilliseconds} ms\n");

            time = sw.ElapsedMilliseconds;

            return sortedArray;

        }

    }

}
