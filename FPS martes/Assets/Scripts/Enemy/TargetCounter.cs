using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    public int yellow;
    public int white;
    public int blue;
    public int red;

    [SerializeField] private GameObject _targetsPanel;
    [SerializeField] private TMP_Text _counterText1;
    [SerializeField] private TMP_Text _counterText2;
    [SerializeField] private TMP_Text _counterText3;
    [SerializeField] private TMP_Text _counterText4;

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
        _targetsPanel.SetActive(true);
        Target[] targets = new Target[4];
        targets[0] = new Target(yellow, "Yellow");
        targets[1] = new Target(white, "White");
        targets[2] = new Target(red, "Red");
        targets[3] = new Target(blue, "Blue");
        
        Quicksort.QuickSort(targets, 0, 3);

        //Debug.Log("Sorted:");
        //for (int i = 0; i < targets.Length; i++)
        //{
        //    Debug.Log(targets[i].targetName + ": " + targets[i].score);
        //}
        if (targets != null && targets.Length > 0)
        {
            _counterText1.text = targets[3].targetName.ToString() + ": " + targets[3].score.ToString();
            _counterText2.text = targets[2].targetName.ToString() + ": " + targets[2].score.ToString();
            _counterText3.text = targets[1].targetName.ToString() + ": " + targets[1].score.ToString();
            _counterText4.text = targets[0].targetName.ToString() + ": " + targets[0].score.ToString();
        }
        else
        {
            Debug.LogWarning("Targets array is null or empty.");
        }
    }
}
