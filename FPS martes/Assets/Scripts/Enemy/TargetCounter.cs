using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCounter : MonoBehaviour
{
    public int yellow;
    public int white;
    public int blue;
    public int red;
    private void Start()
    { 
    }
    public void PlusYellow()
    {
        yellow++;
    }
    public void PlusWhite()
    {
        white++;
    }
    public void PlusRed()
    {
        red++;
    }
    public void PlusBlue()
    {
        blue++;
    }
    public void SortAndPrint()
    {
        Target[] targets = new Target[4];
        targets[0] = new Target(yellow, "Yellow");
        targets[1] = new Target(white, "White");
        targets[2] = new Target(red, "Red");
        targets[3] = new Target(blue, "Blue");
        try
        {
            Quicksort.QuickSort(targets, 0, 3);

            Debug.Log("Sorted:");
            for (int i = 0; i < targets.Length; i++)
            {
                Debug.Log(targets[i].targetName + ": " + targets[i].score);
            }
        }
        catch (Exception ex)
        {

            Debug.LogError("Error during sorting and printing: " + ex.Message);
        }
    }
}
