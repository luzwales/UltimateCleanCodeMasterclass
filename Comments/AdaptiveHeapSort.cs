public class AdaptiveHeapSort
{
    //reasonable comment example:
    //Implements the Adaptive Heap Sort algorithm
    // https://en.wikipedia.org/wiki/Adaptive_heap_sort
    public static void Sort(int[] input)
    {
        int length = input.Length;

        // Build the initial max-heap
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            Heapify(input, length, i);
        }

        for (int i = length - 1; i > 0; i--)
        {
            // Swap the root element (maximum) with the last element
            int temp = input[0];
            input[0] = input[i];
            input[i] = temp;

            // Call heapify on the reduced heap
            Heapify(input, i, 0);
        }
    }

    private static void Heapify(int[] input, int n, int i)
    {
        int largest = i;
        int leftChild = 2 * i + 1;
        int rightChild = 2 * i + 2;

        // Find the largest element among the root, left child, and right child
        if (leftChild < n && input[leftChild] > input[largest])
        {
            largest = leftChild;
        }

        if (rightChild < n && input[rightChild] > input[largest])
        {
            largest = rightChild;
        }

        // If the largest element is not the root, swap them and recursively heapify the affected sub-tree
        if (largest != i)
        {
            int swap = input[i];
            input[i] = input[largest];
            input[largest] = swap;

            Heapify(input, n, largest);
        }
    }
}
