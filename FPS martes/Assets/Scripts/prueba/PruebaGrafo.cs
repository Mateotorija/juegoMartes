using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PruebaNodoGrafo
{
    public float x;
    public float z;

    public PruebaNodoGrafo(float pX, float pZ)
    {
        x = pX;
        z = pZ;
    }
}


public class PruebaGrafo : MonoBehaviour
{ 
    [SerializeField] public int inicio = 0;
    [SerializeField] public int final = 6;
    [SerializeField] public List<GameObject> nodos;
    public List<int> ruta;
    public GameObject enemigo;

    private int[,] mAdyacencia;
    private int[] indegree;
    [SerializeField] private int cantNodos = 7;
    public PruebaNodoGrafo[] nodosCoords;
    private bool inicializado = false;

    // Start is called before the first frame update
    void Start()
    {
        //iniciamos matriz de adyacencia
        mAdyacencia = new int[cantNodos, cantNodos];

        //intanciamos arreglo de indegree
        indegree = new int[cantNodos];

        //instanciamos el arreglo con las coorenadas de nodos 
        nodosCoords = new PruebaNodoGrafo[cantNodos];

        ruta = new List<int>();

        AdicionaArista(0, 1);
        AdicionaArista(1, 2);
        AdicionaArista(2, 3);
        AdicionaArista(3, 4);
        AdicionaArista(4, 5);
        AdicionaArista(5, 6);

        for (int i = 0; i< nodos.Count; i++)
        {
            AdicionaCoords(i, nodos[i].transform.position.x, nodos[i].transform.position.z);
        }

        inicializado = true;

        enemigo.transform.position = new Vector3(nodosCoords[inicio].x, 0.5f, nodosCoords[inicio].z);

        CalculaRuta();
    }

    private void OnDisable()
    {
        inicializado = false;
    }

    public void AdicionaArista(int pNodoInicio, int pNodoFinal)
    {
        mAdyacencia[pNodoInicio, pNodoFinal] = 1;

    }

    public void AdicionaCoords(int pNodo, float pX, float pZ)
    {
        nodosCoords[pNodo] = new PruebaNodoGrafo(pX, pZ);
    }

    private void OnDrawGizmos()
    {
        if (inicializado)
        {
            foreach(PruebaNodoGrafo miNodo in nodosCoords)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(new Vector3(miNodo.x, 0, miNodo.z), 0.5f);
            }

            int n = 0;
            int m = 0;

            for (n = 0; n < cantNodos; n++)
            {
                for(m = 0; m < cantNodos; m++)
                {
                    if(mAdyacencia[n, m] != 0)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(new Vector3(nodosCoords[n].x, 0, nodosCoords[n].z),
                                        new Vector3(nodosCoords[m].x, 0, nodosCoords[m].z));
                    }
                }
            }
        }

    }

    public int ObtenerAdyacencia(int pFila, int pColumna)
    {
        return mAdyacencia[pFila, pColumna];
    }

    public void CalcularIndegree()
    {
        int n = 0;
        int m = 0;
        
        for (n = 0; n < cantNodos; n++)
        {
            for (m = 0; m < cantNodos; m++)
            {
                if(mAdyacencia[m, n] == 1)
                {
                    indegree[n]++;
                }
            }
        }
    }

    public int EncuentraIO()
    {
        bool encontrado = false;
        int n = 0;

        for (n = 0; n< cantNodos; n++)
        {
            if (indegree[n] == 0)
            {
                encontrado = true;
                break;
            }
        }
        if (encontrado)
        {
            return n;
        }
        else
            return 1;
    }

    public void DecrementaIndegree(int pNodo)
    {
        indegree[pNodo] = -1;

        int n = 0;

        for (n = 0; n < cantNodos; n++)
        {
            if (mAdyacencia[pNodo, n] == 1)
            {
                indegree[n]--;
            }
        }
    }

    public void CalculaRuta()
    {
        int[,] tabla = new int[cantNodos, 3];

        int n = 0;
        int distancia = 0;
        int m = 0;

        for(n = 0; n < cantNodos; n++)
        {
            tabla[n, 0] = 0;
            tabla[n, 1] = int.MaxValue;
            tabla[n, 2] = 0;
        }

        tabla[inicio, 1] = 0;

        for(distancia = 0; distancia < cantNodos; distancia++)
        {
            for (n = 0; n< cantNodos; n++)
            {
                if((tabla[n, 0] == 0) && (tabla[n, 1] == distancia))
                {
                    tabla[n, 0] = 1;
                    for(m = 0; m< cantNodos; m++)
                    {
                        if (ObtenerAdyacencia(n, m)== 1)
                        {
                            if(tabla[m, 1]== int.MaxValue)
                            {
                                tabla[m, 1] = distancia + 1;
                                tabla[m, 2] = n;
                            }
                        }
                    }
                }
            }
        }

        ruta.Clear();

        int nodo = final;

        while(nodo != inicio)
        {
            ruta.Add(nodo);
            nodo = tabla[nodo, 2];
        }
        ruta.Add(inicio);

        ruta.Reverse();
    }

    
}
