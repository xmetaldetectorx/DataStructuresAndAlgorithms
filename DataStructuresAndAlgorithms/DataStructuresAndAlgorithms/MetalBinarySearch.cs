using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public static class MetalBinarySearch
    {
        public static int MetalBS(int[] sortedArray, int start, int end, int num)
        {
            if (start > end)
                return -1;
            int mid = start+(end-start) / 2;
            if (num == sortedArray[mid])
                return mid;
            else if (num < sortedArray[mid])
                return MetalBS(sortedArray, start, mid - 1, num);
            else if (num > sortedArray[mid])
                return MetalBS(sortedArray, mid + 1, end, num);         
            return -1;
        }
    }
}
