using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksort : MonoBehaviour
{
    static public void QuickSort(Target[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);

            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }
    static public int Partition(Target[] arr, int left, int right)
    {
        //Seleccionar el elemento más a la derecha como pivote
        int pivot = arr[right].score; 

        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            //Si el elemento actual es menor o igual al pivote
            if (arr[j].score <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        //Intercambiar el pivote con el elemento en la posición correcta
        Swap(arr, i + 1, right);

        //Devolver la nueva posición del pivote
        return i + 1;
    }

    static public void Swap(Target[] arr, int i, int j)
    {
        Target temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}