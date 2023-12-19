using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTime : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public float CurrentTime => currentTime;
    public bool IsEndRound;
    public int RoundCount
    {
        get { return _roundCount; }
        set { _roundCount = value; }
    }
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text countDownText;
    private float currentTime = 0;
    [SerializeField] private int _roundCount = 1;
    [SerializeField] private float startingTime = 20f;
    [SerializeField] private GameObject _endRoundPanel;
    [SerializeField] private ABBHighScore _abbHighscore;
    [SerializeField] private Score _score;
    [SerializeField] private TargetCounter _counter;
    private bool zero;
    private bool oneTime;
    #endregion 

    #region UNITY_METHODS
    void Start()
    {
        InitRoundTime();
        zero = false;
        oneTime = false;
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
        oneTime = false;
    }
    private void CountToZero()
    {
        if (currentTime <= 0 && !oneTime)
        {
            currentTime = 0;
            _gameManager.Init();
            EndRound();
            if(!zero)
                _abbHighscore.MostrarPuntajes();
            zero = true;
            _gameManager.IsPlaying = false;
            if (_score._score >= 120)
                _gameManager._winText.SetActive(true);
            else
                _gameManager._losserText.SetActive(true);
            //_score.UpdateText();
            _counter.SortAndPrint();
            oneTime = true;
        }
    }
    private void EndRound()
    {
        _endRoundPanel.SetActive(true);
        IsEndRound = true;
    }
    #endregion
}