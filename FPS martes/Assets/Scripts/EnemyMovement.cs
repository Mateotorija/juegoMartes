using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;

    private Transform targets;
    private int wavepointIndex = 0;

    private void Start()
    {
        targets = Waypoints.points[0];
        
    }

    private void Update()
    {
        Vector3 dir = targets.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targets.position) <+ 0.2f)
        {
            GetNextWaypoint();
            transform.LookAt(targets);
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Die();
        }
        wavepointIndex++;
        targets = Waypoints.points[wavepointIndex];
    }

    void Die()
    {
        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}