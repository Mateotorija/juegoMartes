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
    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        UpdateScoreText();
    }
    #endregion

    #region METHODS
    private void UpdateScoreText() => _scoreText.text = _score.ToString("0");
    public void ScorePoints(int points)
    {
        _score += points;
    }
    #endregion
}