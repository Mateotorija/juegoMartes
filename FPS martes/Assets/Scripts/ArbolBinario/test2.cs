using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class test2 : MonoBehaviour
{
    public ABB scores = new ABB();
    private string filePath;
    //public List<Jugador> playerList = new List<Jugador>();
    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "playerList.json");
        LoadPlayerList();
    }
    public void AddPlayer()
    {
        string name = PlayerPrefs.GetString("Player");
        int lastScore = PlayerPrefs.GetInt("Score");
        Jugador player = new Jugador(name, lastScore);

        //playerList.Add(player);
        scores.AgregarJugador(player);
        SavePlayerList(player);
        ListPlayer();
        Debug.Log(player.Nombre + player.Puntaje);
    }
    public void ListPlayer()
    {
        //playerList = scores.ObtenerJugadoresEnOrden();
        //Debug.Log(playerList.Count);
    }
    private void SavePlayerList(Jugador playerList)
    {
        //List<Jugador> playerList = scores.ObtenerJugadoresEnOrden();
        string playerListJson = JsonUtility.ToJson(playerList);
        File.WriteAllText(filePath, playerListJson);
        Debug.Log("Se guardó el JSON en " + filePath);
    }
    private void LoadPlayerList()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("Se cargo el json");
            string playerListJson = File.ReadAllText(filePath);
            List<Jugador> playerList = JsonUtility.FromJson<List<Jugador>>(playerListJson);
            scores.IncializarArbol();
            scores.LoadPlayerFromList(playerList);
            Debug.Log("PlayerList JSON: " + playerListJson);
            //UnityEditor.EditorUtility.OpenWithDefaultApp(filePath);
        }
    }
}