using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksort : MonoBehaviour
{

    static public void quickSort(Target[] arr, int left, int right)
    {
        int pivot;
        if(left < right)
        {
            pivot = Partition(arr, left, right);
            if (pivot > 1)
                quickSort(arr, left, pivot - 1);
            if(pivot + 1 < right)
                quickSort(arr, pivot + 1, right);
        }
    }
    static public int Partition(Target[] arr, int left, int right)
    {
        int pivot;
        int aux = (left + right) / 2;
        pivot = arr[aux].score;

        while (true)
        {
            while (arr[left].score < pivot)
                left++;
            while (arr[right].score > pivot)
                right--;
            if (left < right)
            {
                Target temp = arr[right];
                arr[right] = arr[left];
                arr[left] = temp;
            }
            else
                return right;
        }
    }
}
