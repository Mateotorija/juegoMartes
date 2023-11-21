using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private ABB abb;
    public RowUI RowUI;
    public ScoreManager ScoreManager;
    //[SerializeField] private ABBHighScore _abbHighScore;
    [SerializeField] private test2 _test2;
    int currentScore;

    private void Start()
    {
        abb = new ABB();
        int currentScore = PlayerPrefs.GetInt("Score", 0);
        if (currentScore > 0)
        {
            string name = PlayerPrefs.GetString("Player", "{}");

            ScoreManager.AddScore(new Score2(name, currentScore));
            PlayerPrefs.DeleteKey("Score");
        }
        DisplayScores();
        ShowPlayer();
    }
    private void DisplayScores()
    {
        abb.IncializarArbol();
        var scores = ScoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(RowUI, transform).GetComponent<RowUI>();
            row.Rank.text = (i + 1).ToString();
            row.Name.text = scores[i].name;
            row.Score.text = scores[i].score.ToString();
            Jugador jugador = new Jugador(scores[i].name, scores[i].score);
            abb.AgregarJugador(jugador);
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
    public void ShowPlayer()
    {
        List<Jugador> players = abb.ObtenerJugadoresEnOrden();

        for (int i = 0; i < players.Count; i++)
        {
            Debug.Log((i + 1) + " rank " + players[i].Nombre + " - points: " + players[i].Puntaje);
        }
    }
}
