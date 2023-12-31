using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System;

public class Gun : MonoBehaviour
{
    public int MagSize 
    {
        get { return _magSize; }
    }
    public bool CanShoot;

    private StarterAssetsInputs _input;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _firePoint;
    //[SerializeField] private float _bulletSpeed = 600f;
    [SerializeField] private int _magSize = 7;
    [SerializeField] private BulletsCount _bulletsCount;
    private GameObject LastBullet;
    private ColaTDA bulletQueue = new ColaBalasTF();
    [SerializeField] private float _cooldown;
    private float lastShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        Reload();
    }
    // Update is called once per frame
    void Update()
    {
        //verificacion de Input
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
    void Shoot() //logica disparo 
    {
        if (bulletQueue.ColaVacia() == false)//verifica si la cola esta vacia 
        {
            if (Time.time - lastShoot < _cooldown)
                return;
            lastShoot = Time.time;
            //intanceo la bala y le agrego velocidad, despues de un segundo se destruye
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.transform.position, transform.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed);  esta logica la voy a pasar a la bala
            //Destroy(bullet, 1f);
            //obtengo la primer bala disparada y la saco de la Queue
            LastBullet = (GameObject)bulletQueue.Primero();
            bulletQueue.Desacolar(LastBullet);
            _bulletsCount.ShootBullet();
        }
    }
    private void Reload() //lleno la Queue de las balas con un for
    {
        for (int i = 0; i < _magSize; i++)
        {
            bulletQueue.Acolar(_bulletPrefab);
        }
        _bulletsCount.Reloaded();
    }
}
