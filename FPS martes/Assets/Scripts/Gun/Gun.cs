using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System;

public class Gun : MonoBehaviour
{
    public bool CanShoot;

    private StarterAssetsInputs _input;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _firePoint;
    [SerializeField] private float _bulletSpeed = 600f;
    [SerializeField] private int _magSize = 7;
    private GameObject LastBullet;
    private ColaTDA colaBalas = new ColaBalasTF();
    
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        Reload();

    }
    // Update is called once per frame
    void Update()
    {
        if (_input.shoot)
        { 
            if(CanShoot)
                Shoot();
            _input.shoot = false;    
        } 

        if (_input.reload)
        {
            Reload();
            _input.reload = false;
        }
    }
    void Shoot()
    {
        if (colaBalas.ColaVacia() == false)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed);
            Destroy(bullet, 1f);
            //colaBalas.Enqueue(bullet);


            LastBullet = (GameObject)colaBalas.Primero();
            colaBalas.Desacolar(LastBullet);
        }
    }
    private void Reload()
    {
        for (int i = 0; i < _magSize; i++)
        {
            colaBalas.Acolar(_bulletPrefab);
        }

    }
    //public object InicializarCola()
    //{
    //    colaBalas = new T colaBalas [100];
    //    _indice = 0;
    //}
}
