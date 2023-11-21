using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafoTest : MonoBehaviour
{
    [SerializeField] private List<Arista> aristas = new();

    private GrafoMA grafo;

    private int vertices = 14;

    [SerializeField] private List<Nodes> _nodosConectados = new();
    private void Awake()
    {
        grafo = new();
        grafo.InicializarGrafo();

        for(int i=1; i<14; i++)
        {
            grafo.AgregarVertice(i);
        }
        foreach(var arista in aristas)
        {
            grafo.AgregarArista(arista.origen, arista.destino, arista.peso);
        }
        //print($"peso total {grafo.PesoCamino(_nodosConectados)}");
    }
}
