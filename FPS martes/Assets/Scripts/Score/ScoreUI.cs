using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI RowUI;
    public ScoreManager ScoreManager;
    [SerializeField] private ABBHighScore _abbHighScore;
    int currentScore;

    private void Start()
    {
        int currentScore = PlayerPrefs.GetInt("Score", 0);
        if (currentScore > 0)
        {
            string name = PlayerPrefs.GetString("Player", "{}");
            Jugador newPlayer = new Jugador(name, currentScore);
            _abbHighScore.abb.AgregarJugador(newPlayer);
            ScoreManager.AddScore(new Score2(name, currentScore));
        }
        DisplayScores();
    }
    private void DisplayScores()
    {
        var scores = ScoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(RowUI, transform).GetComponent<RowUI>();
            row.Rank.text = (i + 1).ToString();
            row.Name.text = scores[i].name;
            row.Score.text = scores[i].score.ToString();
        }
    }
    public void ResetScores()
    {
        ScoreManager.ResetScore();
        // Limpia las filas anteriores antes de mostrar los puntajes actualizados
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        // Muestra los puntajes actualizados después de restablecer
        DisplayScores();
    }
}
