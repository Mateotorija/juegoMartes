using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public RoundTime RoundCount;
    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _yellowText;
    [SerializeField] private TMP_Text _whiteText;
    [SerializeField] private TMP_Text _redText;
    [SerializeField] private TMP_Text _blueText;

    [SerializeField] public int _score;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
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
    public void UpdateYellowText() => _yellowText.text = "Yellow: " + EnemyMovement.YellowTarget.ToString("0");
    public void UpdateWhiteText() => _whiteText.text = "White: " + EnemyMovement.WhiteTarget.ToString("0");
    public void UpdateRedText() => _redText.text = "Red: " + EnemyMovement.RedTarget.ToString("0");
    public void UpdateBlueText() => _blueText.text = "Blue: " + EnemyMovement.BlueTarget.ToString("0");
    public void ScorePoints(int points)
    {
        Debug.Log("Hit");
        _score += points;
        UpdateScoreText();
        Debug.Log("Sumaste ");
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