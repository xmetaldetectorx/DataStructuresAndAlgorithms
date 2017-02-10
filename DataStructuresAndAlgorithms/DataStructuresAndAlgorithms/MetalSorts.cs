using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    static class MetalSorts
    {

        static public void MetalQuickSort(int[] array, int start, int end)
        {
            if(start < end)
            {
                int pIndex = MetalPartition(array, start, end);
                MetalQuickSort(array, start, pIndex - 1);
                MetalQuickSort(array, pIndex + 1, end);
            }
        }

        static private int MetalPartition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int pIndex = start;
            for(int i = start; i < end; i++)
            {
                //keep elements less than pivot towards the left of the array
                if(array[i]<=pivot)
                {
                    //swap a[i] and a[pIndex]
                    int temp = array[i];
                    array[i] = array[pIndex];
                    array[pIndex] = temp;
                    pIndex++;
                }
            }
            //swap a[pIndex] and pivot
            int temp2 = array[pIndex];
            array[pIndex] = array[end];
            array[end] = temp2;
            return pIndex;
        }

        static public void MetalMergeSort(int[] array, int arrayLength)
        {
            if (arrayLength < 2)
                return;
            int midPoint = arrayLength / 2;
            int[] left = new int[midPoint];
            int[] right = new int[arrayLength - midPoint];

            for(int i = 0; i <= midPoint-1; i++)
            {
                left[i] = array[i];
            }
            for(int i = midPoint; i <= arrayLength-1; i++)
            {
                right[i - midPoint] = array[i];
            }
            MetalMergeSort(left, left.Length);
            MetalMergeSort(right, right.Length);
            Merge(left, right, array);
        }

        static private void Merge(int[] left, int[] right, int[] array)
        {
            int lIndex =0,
                rIndex =0,
                aIndex = 0;
            while (lIndex < left.Length && rIndex < right.Length)
            {
                if(left[lIndex] <= right[rIndex])
                {
                    array[aIndex] = left[lIndex];
                    lIndex++;                    
                }
                else
                {
                    array[aIndex] = right[rIndex];
                    rIndex++;
                }
                aIndex++;
            }
            while(lIndex < left.Length)
            {
                array[aIndex] = left[lIndex];
                lIndex++;
                aIndex++;
            }
            while(rIndex < right.Length)
            {
                array[aIndex] = right[rIndex];
                rIndex++;
                aIndex++;
            }
        }

    }
}
