using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;

    private GrafoMA _grafo;
    private Nodos[] nodes;
    private int currentNodeIndex = 0;
    private void Start()
    {
        _grafo = GrafoManager.Grafo;

        //obtener la ruta calculada desde GrafoManager
        nodes = GrafoManager.DijkstraPath;

        //Establecer el nodo de destino inicial
        SetTargetNode(currentNodeIndex);
    }
    private void Update()
    {
        MoveToTarget();
    }
    void MoveToTarget()
    {
        //Verificar la distancia al nodo de destino
        if(Vector3.Distance(transform.position, nodes[currentNodeIndex].Position) <= 0.2f)
        {
            //Avanzar al siguiente nodo
            currentNodeIndex++;

            //Verificar si hay mas nodos en la ruta
            if(currentNodeIndex < nodes.Length)
            {
                SetTargetNode(currentNodeIndex);
            }
            else
            {
                //Llego al final de la ruta, llamar al metodo
                Die();
            }
        }
        else
        {
            //Moverse hacia al nodo de destino
            Vector3 dir = nodes[currentNodeIndex].Position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
    void SetTargetNode(int index)
    {
        //Orientar hacia el nodo destino
        transform.LookAt(nodes[index].Position);
    }
    public void Die()
    {
        //Bajar el numero de targets vivos
        WaveSpawner.EnemiesAlive++;

        Destroy(gameObject);
    }
}