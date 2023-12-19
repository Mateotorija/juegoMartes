using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    public static int[] distance;
    public static Nodos[] nodes;

    private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int v = 0; v < verticesCount; ++v)
        {
            // obtengo siempre el nodo con la menor distancia calculada
            // solo lo verifico en los nodos que no tienen seteado ya un camino (shortestPathTreeSet[v] == false)
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        // devuelvo el nodo calculado
        return minIndex;
    }

    public static Nodos[] AlgDijkstra(GrafoMA grafo, int source, Nodos[] Nodos, int objective)
    {
        // obtengo la matriz de adyacencia del TDA_Grafo
        int[,] graph = grafo.MAdy;

        // obtengo la cantidad de nodos del TDA_Grafo
        int verticesCount = grafo.cantNodos;

        // obtengo el indice del nodo elegido como origen a partir de su valor
        source = grafo.Vert2Indice(source);

        // vector donde se van a guardar los resultados de las distancias entre 
        // el origen y cada vertice del grafo
        distance = new int[verticesCount];


        bool[] shortestPathTreeSet = new bool[verticesCount];

        int[] nodos1 = new int[verticesCount];
        int[] nodos2 = new int[verticesCount];

        for (int i = 0; i < verticesCount; ++i)
        {
            // asigno un valor maximo (inalcanzable) como distancia a cada nodo
            // cualquier camino que se encuentre va a ser menor a ese valor
            // si no se encuentra un camino, este valor maximo permanece y es el 
            // indica que no hay ningun camino entre el origen y ese nodo
            distance[i] = int.MaxValue;

            // seteo en falso al vector que guarda la booleana cuando se encuentra un camino
            shortestPathTreeSet[i] = false;

            nodos1[i] = nodos2[i] = -1;
        }

        // la distancia al nodo origen es 0
        distance[source] = 0;
        nodos1[source] = nodos2[source] = grafo.Etiqs[source];
        // recorro todos los nodos (vertices)
        for (int count = 0; count < verticesCount - 1; ++count)
        {
            int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[u] = true;

            // recorro todos los nodos (vertices)
            for (int v = 0; v < verticesCount; ++v)
            {
                // comparo cada nodo (que aun no se haya calculado) contra el que se encontro que tiene la menor distancia al origen elegido
                if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                {
                    // si encontr� una distancia menor a la que tenia, la reasigno la nodo
                    distance[v] = distance[u] + graph[u, v];
                    // guardo los nodos para reconstruir el camino
                    nodos1[v] = grafo.Etiqs[u];
                    nodos2[v] = grafo.Etiqs[v];


                }
            }
        }

        nodes = new Nodos[verticesCount];
        //construyo camino de nodos
        int nodOrig = grafo.Etiqs[source];

        List<int> l1 = new List<int>();
        l1.Add(nodos1[objective]);
        l1.Add(nodos2[objective]);

        while (l1.Count < verticesCount)
        {
            bool added = false;
            for (int k = 0; k < verticesCount; k++)
            {
                if (!l1.Contains(nodos1[k]))
                {
                    l1.Insert(0, nodos1[k]);
                    added = true;
                    break;
                }
                else if (!l1.Contains(nodos2[k]))
                {
                    l1.Add(nodos2[k]);
                    added = true;
                    break;
                }
            }
            if (!added)
                break;
        }
        Debug.Log($"Camino: {string.Join(" -> ", l1)}");

        if (l1.Count == verticesCount)
        {
            for (int k = 0; k < l1.Count; k++)
            {
                nodes[k] = Nodos[l1[k]-1];
            }
        }
        else
        {
            Debug.LogError("Error: No se encontr� un camino v�lido.");
        }

        return nodes;

        //for (int j = 0; j < verticesCount; j++)
        //{
        //    if (nodos1[j] != -1 /*&& nodos2[j] == objective*/)
        //    {

        //        while (l1.Count < verticesCount/*l1[0] != nodOrig*/)
        //        {
        //            bool added = false; //
        //            for (int k = 0; k < verticesCount; k++)
        //            {
        //                if (!l1.Contains(nodos1[k])/*k != source && l1[0] == nodos2[k]*/)
        //                {
        //                    l1.Insert(0, nodos1[k]);
        //                    added = true; //
        //                    break;
        //                }
        //                else if (!l1.Contains(nodos2[k]))
        //                {
        //                    l1.Add(nodos2[k]);
        //                    added = true;
        //                    break;
        //                }
        //            }
        //            if (!added)
        //                break;
        //            nodOrig = l1[0];
        //        }

        //        Debug.Log($"Camino: {string.Join(" -> ", l1)}");

        //        if (l1.Count <= nodes.Length)
        //        {
        //            for (int k = 0; k < l1.Count; k++)
        //            {
        //                nodes[k] = Nodos[l1[k] - 1];
        //            }
        //        }
        //        else
        //        {
        //            Debug.LogError("Error: El tama�o del camino excede el tama�o del array 'nodes'.");
        //        }

        //        //for (int k = 0; k < l1.Count; k++)
        //        //{
        //        //    if (k == 0)
        //        //    {
        //        //        nodes[k] = Nodos[source];
        //        //    }
        //        //    else
        //        //    {
        //        //        nodes[k] = Nodos[l1[k] - 1];
        //        //        //int nodeIndex = l1[j];
        //        //        //if(nodeIndex >= 0 && nodeIndex < Nodos.Length)
        //        //        //{
        //        //        //    nodes[j] = Nodos[nodeIndex];
        //        //        //    Debug.Log($"Nodo[{j}]: {nodes[j].IdNode}");
        //        //        //    //nodes[j] = Nodos[l1[j]];
        //        //        //}
        //        //        //else
        //        //        //{
        //        //        //    Debug.LogError($"Error: �ndice {nodeIndex} fuera de l�mites.");
        //        //        //}
        //        //    }
        //        //    //Debug.Log($"Nodo[{j}]: {nodes[j].IdNode}");
        //        //}
        //    }
        //}

        //return nodes;
    }
}