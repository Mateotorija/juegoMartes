using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public RoundTime RoundCount;
    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text _scoreText;
    private int _score;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        InitScore();
    }
    #endregion

    #region METHODS
    public void UpdateScoreText() => _scoreText.text = "Score: " + _score.ToString("0");
    public void ScorePoints()
    {
        _score += 10;
        UpdateScoreText();
        Debug.Log("Sumaste ");
    }
    public void SaveScore()
    {
        string scoreKey = "PlayerScore_Round" + RoundCount.RoundCount;

        if (PlayerPrefs.HasKey(scoreKey))
        {
            RoundCount.RoundCount++;
            scoreKey = "PlayerScore_Round" + RoundCount.RoundCount;
        }
        PlayerPrefs.SetInt(scoreKey, _score);
        PlayerPrefs.Save();
    }
    public void InitScore()
    {
        _score = 0;
        UpdateScoreText();
    }
    #endregion
}