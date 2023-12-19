using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterMenu : MonoBehaviour
{
    public int yellow;
    public int white;
    public int blue;
    public int red;
    public int defaultCounter = 0;

    private void Start()
    {
        LoadSettings();
    }
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Yellow"))
            yellow = PlayerPrefs.GetInt("Yellow");
        else
        {
            yellow = defaultCounter;
            PlayerPrefs.SetInt("Yellow", defaultCounter);
        }
        if (PlayerPrefs.HasKey("White"))
            white = PlayerPrefs.GetInt("White");
        else
        {
            white = defaultCounter;
            PlayerPrefs.SetInt("White", defaultCounter);
        }
        if (PlayerPrefs.HasKey("Red"))
            red = PlayerPrefs.GetInt("Red");
        else
        {
            red = defaultCounter;
            PlayerPrefs.SetInt("Red", defaultCounter);
        }
        if (PlayerPrefs.HasKey("Blue"))
            blue = PlayerPrefs.GetInt("Blue");
        else
        {
            blue = defaultCounter;
            PlayerPrefs.SetInt("Blue", defaultCounter);
        }
    }
}
