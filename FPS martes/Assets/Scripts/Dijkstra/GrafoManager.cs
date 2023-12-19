using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Aristas
{
    [SerializeField] public int origen;
    [SerializeField] public int destino;
    [SerializeField] public int peso;
}
public class GrafoManager : MonoBehaviour
{
    public static GrafoMA Grafo;
    public static Nodos[] DijkstraPath;

    private void Start()
    {
        //Creo una nueva instancia de GrafoMA y la inicializo
        Grafo = new GrafoMA();
        Grafo.InicializarGrafo();

        //Encuentro todos los objetos de tipo Nodos en la escena
        Nodos[] nodos = FindObjectsOfType<Nodos>();

        //Debug.Log($"Número de nodos encontrados: {nodos.Length}");

        //Agrego los nodos al grafo
        foreach (var nodo in nodos)
        {
            Grafo.AgregarVertice(nodo.IdNode);

            Grafo.Nodes[Grafo.cantNodos - 1] = nodo.gameObject;

            //Debug.Log($"Nodo agregado - ID: {nodo.IdNode}");
        }
        //Agrego las aristas al grafo
        foreach (var nodo in nodos)
        {
            foreach (var neig in nodo.Neighbors)
            {
                Grafo.AgregarArista(nodo.IdNode, neig.IdNode, nodo.Cost);

                //Debug.Log($"Arista agregada - Origen: {nodo.IdNode}, Destino: {neig.IdNode}, Peso: {nodo.Cost}");
            }
        }
        //Creo un arreglo de nodos a partir del array encontrado
        Nodos[] nodosArray = new Nodos[nodos.Length];

        for (int i = 0; i < nodos.Length; i++)
        {
            nodosArray[i] = nodos[i];
        }
        //Calculo la ruta utilizando Dijkstra y la asigno
        DijkstraPath = CalculatePathDijkstra(1, 13, nodosArray);
    }

    private Nodos[] CalculatePathDijkstra(int sourceNodeId, int objetiveNodeId, Nodos[] allNodes)
    {
        if (sourceNodeId < 0 || sourceNodeId >= Grafo.cantNodos || objetiveNodeId < 0 || objetiveNodeId >= Grafo.cantNodos)
        {
            Debug.LogError("Error: Nodos de origen o destino fuera de rango.");
            return null;
        }
        //Llamo al metodo AlgDijkstra de Dijkstra para calcular la ruta
        return Dijkstra.AlgDijkstra(Grafo, sourceNodeId, allNodes, objetiveNodeId);
    }
}
