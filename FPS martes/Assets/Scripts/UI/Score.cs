using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public RoundTime RoundCount;
    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text _scoreText;
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
    }
    #endregion

    #region METHODS
    public void UpdateScoreText() => _scoreText.text = "Score: " + _score.ToString("0");
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