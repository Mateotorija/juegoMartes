using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _firePoint;
    [SerializeField] private float _bulletSpeed = 600f;
    Queue colaBalas = new Queue();
 
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.shoot)
        { 
            Shoot();
            _input.shoot = false;    
        }
        foreach (object obj in colaBalas)
        {
            Debug.Log(obj.ToString() + "\n");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed);
        Destroy(bullet, 1f);
        colaBalas.Enqueue(bullet);
        
       
    }
}
