using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    public List<RoundScore> scoreList = new List<RoundScore>();
    [SerializeField] private ABBHighScore _ABBHighScore;

    private void Start()
    {
        int roundNumber = 1;
        bool scoreExists = true;
        while (scoreExists)
        {
            string scoreKey = "PlayerScore_Round" + roundNumber;
            if (PlayerPrefs.HasKey(scoreKey))
            {
                int score = PlayerPrefs.GetInt(scoreKey);
                scoreList.Add(new RoundScore { RoundNumber = roundNumber, Score = score });
                roundNumber++;
                //_ABBHighScore.GenerarPuntajes();
            }
            else
            {
                scoreExists = false;
            }
            scoreList.Sort((a, b) => b.Score.CompareTo(a.Score));

            foreach (var scoreInfo in scoreList)
            {
                Debug.Log("Ronda " + scoreInfo.RoundNumber + ": " + scoreInfo.Score);
            }
        }
    }

    private void Update()
    {
        
    }
}