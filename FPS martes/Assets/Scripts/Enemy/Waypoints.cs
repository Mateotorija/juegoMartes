using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private GrafoMA grafo;
    // empty con los child waypoints en array y se cuentan su lenght con un for
    public static Transform[] points;
    //[SerializeField] private List<Nodo> nodosID;
    //private int cantNodos;
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

        grafo = new GrafoMA();
        grafo.InicializarGrafo();

        for (int i = 0; i < points.Length; i++)
        {
            grafo.AgregarVertice(i);
        }

        int[] aristas_origen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        // vector de aristas - vertices destino
        int[] aristas_destino = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        // vector de aristas - pesos
        int[] aristas_pesos = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        for (int i = 0; i < aristas_pesos.Length; i++)
        {
            grafo.AgregarArista(aristas_origen[i], aristas_destino[i] - 1, aristas_pesos[i]);
        }

        Debug.Log("\nListado de Etiquetas de los nodos");
        for (int i = 0; i < grafo.Etiqs.Length; i++)
        {
            if (grafo.Etiqs[i] != 0)
            {
                Debug.Log("Nodo: " + grafo.Etiqs[i].ToString());
            }
        }

        Console.WriteLine("\nListado de Aristas (Inicio, Fin, Peso)");
        for (int i = 0; i < grafo.cantNodos; i++)
        {
            for (int j = 0; j < grafo.cantNodos; j++)
            {
                if (grafo.MAdy[i, j] != 0)
                {
                    // obtengo la etiqueta del nodo origen, que está en las filas (i)
                    int nodoIni = grafo.Etiqs[i];
                    // obtengo la etiqueta del nodo destino, que está en las columnas (j)
                    int nodoFin = grafo.Etiqs[j];
                    Console.WriteLine(nodoIni.ToString() + ", " + nodoFin.ToString() + ", " + grafo.MAdy[i, j].ToString());
                }
            }
        }

        AlgDijkstra.Dijkstra(grafo, 1);

        MuestroResultadosAlg(AlgDijkstra.distance, grafo.cantNodos, grafo.Etiqs, AlgDijkstra.nodos);
    }

    private static void MuestroResultadosAlg(int[] distance, int verticesCount, int[] Etiqs, string[] caminos)
    {
        string distancia = "";

        Console.WriteLine("Vertice    Distancia desde origen    Nodos");

        for (int i = 0; i < verticesCount; ++i)
        {
            if (distance[i] == int.MaxValue)
            {
                distancia = "---";
            }
            else
            {
                distancia = distance[i].ToString();
            }
            Console.WriteLine("{0}\t  {1}\t\t\t   {2}", Etiqs[i], distancia, caminos[i]);
        }
    }
}
