using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTime : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public GameManager GameManager;
    public float CurrentTime => currentTime;
    public bool IsEndRound;
    public int RoundCount
    {
        get { return _roundCount; }
        set { _roundCount = value; }
    }
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text countDownText;
    private float currentTime = 0;
    private int _roundCount = 1;
    [SerializeField] private float startingTime = 20f;
    [SerializeField] private GameObject _endRoundPanel;
    #endregion

    #region UNITY_METHODS
    void Start()
    {
        InitRoundTime();
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
    public void InitRoundTime()
    {
        IsEndRound = false;
        currentTime = startingTime;
        _endRoundPanel.SetActive(false);
    }
    private void CountToZero()
    {
        if (currentTime <= 0)
        {
            currentTime = 0;
            GameManager.Init();
            EndRound();
        }
    }
    private void EndRound()
    {
        _endRoundPanel.SetActive(true);
        IsEndRound = true;
    }
    #endregion
}