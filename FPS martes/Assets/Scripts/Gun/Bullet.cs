using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Power = 20f;
    public float LifeTime = 3f;

    private float time = 0;
    [SerializeField] private LayerMask _hitteableLayer;
    private ABBHighScore highscore;
    Rigidbody bulletRB;
    private void Start()
    {
        bulletRB = GetComponent<Rigidbody>();

        bulletRB.velocity = this.transform.forward * Power;
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= LifeTime)
            Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _hitteableLayer) != 0)
        {
            //highscore.Puntaje++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}