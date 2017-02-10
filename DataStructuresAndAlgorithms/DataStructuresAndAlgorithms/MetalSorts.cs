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
                //get pivot location from partitioned array
                int pIndex = MetalPartition(array, start, end);
                //quicksort left of pivot
                MetalQuickSort(array, start, pIndex - 1);
                //quicksort right of pivot
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
            //find midpoint and split array into two 
            int midPoint = arrayLength / 2;
            int[] left = new int[midPoint];
            int[] right = new int[arrayLength - midPoint];

            //copy elements 
            for(int i = 0; i <= midPoint-1; i++)
            {
                left[i] = array[i];
            }
            for(int i = midPoint; i <= arrayLength-1; i++)
            {
                right[i - midPoint] = array[i];
            }

            //Call mergesort on left array
            MetalMergeSort(left, left.Length);
            //Call mergesort on right array
            MetalMergeSort(right, right.Length);
            //Merges left and right arrays by comparing each element
            Merge(left, right, array);
        }

        static private void Merge(int[] left, int[] right, int[] array)
        {
            int lIndex =0,
                rIndex =0,
                aIndex = 0;
            //Start copying elements of each array by comparing
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
            //copy leftover left
            while(lIndex < left.Length)
            {
                array[aIndex] = left[lIndex];
                lIndex++;
                aIndex++;
            }
            //copy leftover right
            while(rIndex < right.Length)
            {
                array[aIndex] = right[rIndex];
                rIndex++;
                aIndex++;
            }
        }

    }
}
