using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTime : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public float CurrentTime => currentTime;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text countDownText;
    private float currentTime = 0;
    [SerializeField] private float startingTime = 20f;
    #endregion

    #region UNITY_METHODS
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        UpdateRoundTime();
        UpdateTextRoundTime();
        CountToZero();
    }
    #endregion

    #region METHODS
    private void UpdateRoundTime() => currentTime -= 1 * Time.deltaTime;
    private void UpdateTextRoundTime() => countDownText.text = currentTime.ToString("0");
    private void CountToZero()
    {
        if (currentTime <= 0)
            currentTime = 0;
    }
    #endregion
}