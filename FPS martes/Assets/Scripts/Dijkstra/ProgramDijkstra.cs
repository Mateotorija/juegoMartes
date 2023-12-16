using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProgramDijkstra : MonoBehaviour
{
    static void Main(string[] args)
    {
        Console.WriteLine("Programa Iniciado\n");

        // creo la estructura de grafos (estatica)
        GrafoMA grafoEst = new GrafoMA();

        // inicializo TDA
        //grafoEst.InicializarGrafo();

        // vector de vértices
        int[] vertices = { 1, 2, 3, 4, 5, 6 };
        // agrego los vértices
        for (int i = 0; i < vertices.Length; i++)
        {
            grafoEst.AgregarVertice(vertices[i]);
        }

        // vector de aristas - vertices origen
        int[] aristas_origen = { 1, 2, 1, 3, 3, 5, 6, 4 };
        // vector de aristas - vertices destino
        int[] aristas_destino = { 2, 1, 3, 5, 4, 6, 5, 6 };
        // vector de aristas - pesos
        int[] aristas_pesos = { 12, 10, 21, 9, 32, 12, 87, 10 };
        // agrego las aristas
        for (int i = 0; i < aristas_pesos.Length; i++)
        {
            grafoEst.AgregarArista(aristas_origen[i], aristas_destino[i], aristas_pesos[i]);
        }

            

        Console.WriteLine("\nAlgoritmo Dijkstra");
        // al algoritmo le paso el TDA_Grafo estático con los datos cargados y el vértice origen
        AlgDijkstra.Dijkstra(grafoEst, 3);
        // muestro resultados
        MuestroResultadosAlg(AlgDijkstra.distance, grafoEst.cantNodos, grafoEst.Etiqs, AlgDijkstra.nodos);


        Console.ReadKey();
    }

    public static void MuestroResultadosAlg(int[] distance, int verticesCount, int[] Etiqs, string[] caminos)
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
