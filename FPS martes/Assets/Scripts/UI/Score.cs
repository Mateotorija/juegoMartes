using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public RoundTime RoundCount;
    public TargetCounter TargetCounter;
    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private TMP_Text _yellowText;
    [SerializeField] private TMP_Text _whiteText;
    [SerializeField] private TMP_Text _redText;
    [SerializeField] private TMP_Text _blueText;
    //[SerializeField] private TMP_Text _counterText1;
    //[SerializeField] private TMP_Text _counterText2;
    //[SerializeField] private TMP_Text _counterText3;
    //[SerializeField] private TMP_Text _counterText4;

    [SerializeField] public int _score;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        TargetCounter = FindObjectOfType<TargetCounter>();
        InitScore();
    }
    private void Update()
    {
        UpdateScoreText();
        UpdateYellowText();
        UpdateWhiteText();
        UpdateRedText();
        UpdateBlueText();
    }
    #endregion

    #region METHODS
    public void UpdateScoreText() => _scoreText.text = "Score: " + _score.ToString("0");
    public void UpdateYellowText() => _yellowText.text = "Yellow: " + TargetCounter.yellow.ToString("0");
    public void UpdateWhiteText() => _whiteText.text = "White: " + TargetCounter.white.ToString("0");
    public void UpdateRedText() => _redText.text = "Red: " + TargetCounter.red.ToString("0");
    public void UpdateBlueText() => _blueText.text = "Blue: " + TargetCounter.blue.ToString("0");
    //public void UpdateText()
    //{
    //    Target[] targets = new Target[4];
    //    targets[0] = new Target(TargetCounter.yellow, "Yellow");
    //    targets[1] = new Target(TargetCounter.white, "White");
    //    targets[2] = new Target(TargetCounter.red, "Red");
    //    targets[3] = new Target(TargetCounter.blue, "Blue");

    //    Quicksort.QuickSort(targets, 0, 3);

    //    _counterText1.text = targets[3].name + ": " + targets[3].score.ToString("0");
    //    _counterText2.text = targets[2].name + ": " + targets[2].score.ToString("0");
    //    _counterText3.text = targets[1].name + ": " + targets[1].score.ToString("0");
    //    _counterText4.text = targets[0].name + ": " + targets[0].score.ToString("0");
    //}
    public void ScorePoints(int points)
    {
        _score += points;
        UpdateScoreText();
    }
    public void SaveCounter()
    {
        PlayerPrefs.SetInt("Yellow", TargetCounter.yellow);
        PlayerPrefs.SetInt("White", TargetCounter.white);
        PlayerPrefs.SetInt("Red", TargetCounter.red);
        PlayerPrefs.SetInt("Blue", TargetCounter.blue);
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", _score);
    }
    public void InitScore()
    {
        _score = 0;
        UpdateScoreText();
    }
    #endregion
}