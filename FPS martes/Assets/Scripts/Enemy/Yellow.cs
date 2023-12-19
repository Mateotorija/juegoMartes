using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Yellow : MonoBehaviour
{
    public float speed = 1f;
    private Transform targets;
    private int wavepointIndex = 0;
    //private TargetCounter counter;
    public UnityEvent onYellowDie;

    private void Start()
    {
        targets = Waypoints.points[0];
        //counter = FindObjectOfType<TargetCounter>();
    }

    // EL PREFAB SE DIRIGE A CADA WAYPOINT

    private void Update()
    {
        Vector3 dir = targets.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targets.position) < +0.2f)
        {
            GetNextWaypoint();
            transform.LookAt(targets);
        }
    }

    // cuando llega la ultimop waypoint muere/desapwnea
    void GetNextWaypoint()
    {
        if (wavepointIndex < Waypoints.points.Length - 1)
        {
            wavepointIndex++;
            targets = Waypoints.points[wavepointIndex];
        }
        else
        {
            Die();
        }
    }
    public void Die()
    {
        WaveSpawner.EnemiesAlive++;
        //TargetCounter counter = FindObjectOfType<TargetCounter>();
        //counter.PlusYellow();
        onYellowDie.Invoke();
        Destroy(gameObject);
    }
}
