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

    private void Start()
    {
        Grafo = new GrafoMA();
        Grafo.InicializarGrafo();

        Nodos[] nodos = FindObjectsOfType<Nodos>();

        Debug.Log($"Número de nodos encontrados: {nodos.Length}");

        foreach (var nodo in nodos)
        {
            Grafo.AgregarVertice(nodo.IdNode);

            Grafo.Nodes[Grafo.cantNodos - 1] = nodo.gameObject;

            Debug.Log($"Nodo agregado - ID: {nodo.IdNode}");
        }
        foreach (var nodo in nodos)
        {
            foreach (var neig in nodo.Neighbors)
            {
                Grafo.AgregarArista(nodo.IdNode, neig.IdNode, nodo.Cost);

                Debug.Log($"Arista agregada - Origen: {nodo.IdNode}, Destino: {neig.IdNode}, Peso: {nodo.Cost}");
            }
        }
    }
    //GrafoMA grafo = new GrafoMA();
    //[SerializeField] List<Aristas> aristas = new();
    //[SerializeField] int cantVertices = 14;
    //[SerializeField] public Nodos[] nodos;
    //public Nodos[] path;
    //int nextPos = 6;

    //private void Awake()
    //{
    //    nodos = new Nodos[cantVertices];
    //    grafo.InicializarGrafo();

    //    for (int i = 0; i < cantVertices; i++)
    //    {
    //        nodos[i] = GameObject.Find("Waypoint" + i).GetComponent<Nodos>();
    //    }
    //    for (int i = 0; i < cantVertices; i++)
    //    {
    //        grafo.AgregarVertice(nodos[i].IdNode);
    //    }

    //    foreach (var arista in aristas)
    //    {
    //        grafo.AgregarArista(arista.origen, arista.destino, arista.peso);
    //    }
    //}

    //public int NextPositionAvailable(int currentPos)
    //{
    //    int newPos = 0;
    //    for (int i = 0; i < cantVertices; i++)
    //    {
    //        if(grafo.ExisteArista(currentPos, i))
    //        {
    //            newPos = i;
    //            break;
    //        }
    //    }
    //    return newPos;
    //}
    //public Vector2 GetPosition(Vector2 vector, int nodo)
    //{
    //    vector = nodos[nodo].gameObject.transform.position;
    //    return vector;
    //}
    //public Nodos[] PathFinding(int currentNode)
    //{
    //    path = new Nodos[cantVertices];
    //    path = Dijkstra.AlgDijkstra(grafo, currentNode, nodos, nextPos);

    //    return path;
    //}
}
