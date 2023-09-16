using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    #endregion

    #region UNITY_METHODS
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        UpdateScoreText();
    }
    #endregion

    #region METHODS
    private void UpdateScoreText() => scoreText.text = score.ToString("0");
    public void ScorePoints(int points)
    {
        score += points;
    }
    #endregion
}