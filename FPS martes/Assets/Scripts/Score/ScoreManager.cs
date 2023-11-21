using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    private ABB abb;
    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);

        abb = new ABB();
        if(sd != null && sd.scores != null)
        {
            foreach (var player in sd.scores)
            {
                abb.AgregarJugador(player);
            }
        }
    }
    public IEnumerable<Jugador> GetHighScores()
    {
        return abb.ObtenerJugadoresEnOrden();
    }
    public void AddScore(Jugador score)
    {
        sd.scores.Add(score);
        abb.AgregarJugador(score);
    }
    private void OnDestroy()
    {
        SaveScore();
    }
    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
    public void ResetScore()
    {
        abb.IncializarArbol();
        sd.scores.Clear();
        SaveScore();
    }
}