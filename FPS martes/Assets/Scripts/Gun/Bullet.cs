using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask _hitteableLayer;
    [SerializeField] private Score score;
    private void Awake()
    {
        score = FindObjectOfType<Score>();
        if (score == null)
            Debug.LogError("no esta");
    }
    void Start()
    {
        
    }

    void Update()
    {
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _hitteableLayer) != 0)
        {
            Debug.Log("Hit" + other);
            //OnCollisionScoreEvent?.Invoke();
            score.ScorePoints();
            Destroy(other.gameObject);
        }
    }
}