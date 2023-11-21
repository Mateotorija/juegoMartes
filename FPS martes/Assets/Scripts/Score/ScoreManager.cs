using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }
    public IEnumerable<Score2> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }
    public void AddScore(Score2 score)
    {
        sd.scores.Add(score);
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
        sd.scores.Clear();
        SaveScore();
    }
}

//{
//    private ABB abb;
//private void Awake()
//{
//    var json = PlayerPrefs.GetString("scores", "{}");
//    ABB loadedABB = JsonUtility.FromJson<ABB>(json);// ?? new ABB();
//    if (loadedABB != null)
//    {
//        abb = loadedABB;
//    }
//    else
//    {
//        abb = new ABB();
//    }
//}
//public IEnumerable<Jugador> GetHighScores()
//{
//    return abb.ObtenerJugadoresEnOrden().OrderByDescending(x => x.Puntaje);
//}
//public void AddScore(Jugador jugador)
//{
//    abb.AgregarJugador(jugador);
//    SaveScore();
//}
//private void OnDestroy()
//{
//    SaveScore();
//}

//public void SaveScore()
//{
//    var json = JsonUtility.ToJson(abb);
//    PlayerPrefs.SetString("scores", json);
//}
//public void ResetScore()
//{
//    abb.IncializarArbol();
//    SaveScore();
//}
//}