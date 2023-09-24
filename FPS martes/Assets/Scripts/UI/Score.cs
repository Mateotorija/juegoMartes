using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;
    #endregion

    #region UNITY_METHODS
    #endregion

    #region METHODS
    public void UpdateScoreText() => _scoreText.text = "Score: " + _score.ToString("0");
    public void ScorePoints()
    {
        _score += 10;
        UpdateScoreText();
        Debug.Log("Sumaste ");
    }
    #endregion
}