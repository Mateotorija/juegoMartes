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

        nodes = GrafoManager.DijkstraPath;

        if(nodes != null && nodes.Length > 0)
        {
            SetTargetNode(currentNodeIndex);
        }
        else
        {
            Debug.LogError("La referencia 'Nodos' es nula.");
        }
    }

    private void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if(Vector3.Distance(transform.position, nodes[currentNodeIndex].Position) <= 0.2f)
        {
            currentNodeIndex++;

            if(currentNodeIndex < nodes.Length)
            {
                SetTargetNode(currentNodeIndex);
            }
            else
            {
                Die();
            }
        }
        else
        {
            Vector3 dir = nodes[currentNodeIndex].Position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }

    void SetTargetNode(int index)
    {
        if(nodes != null && index >= 0 && index < nodes.Length && nodes[index] != null)
        {
            transform.LookAt(nodes[index].Position);
        }
        else
        {
            Debug.LogWarning($"Attempted to access null or out-of-bounds node at index {index}.");
        }
        
    }
    public void Die()
    {
        WaveSpawner.EnemiesAlive++;

        Destroy(gameObject);
    }
}