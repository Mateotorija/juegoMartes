using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask _hitteableLayer;
    [SerializeField] private Score _score;


    //verifica si coliciono con el enemimgo
    public void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _hitteableLayer) != 0)
        {
            //_score.ScorePoints();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}