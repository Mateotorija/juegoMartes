using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private GrafoMA grafo;
    // empty con los child waypoints en array y se cuentan su lenght con un for
    public static Transform[] points;

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
        for (int i = 0; i < points.Length; i++)
        {
            grafo.AgregarArista(i, i, 1);
        }
    }
}
