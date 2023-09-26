using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ColaBalasTF : ColaTDA
{
   //creo la Queue de las Balas
    public Queue BulletQueue => _bulletQueue;
    private Queue _bulletQueue = new Queue();

    int _indice;
    public void Acolar(GameObject GameObject)//Agrega balas a la Queue
    { 
        _bulletQueue.Enqueue(GameObject);
        _indice++;
    }
    public void Desacolar(GameObject LastBullet) //elimina la bala de la Queue
    {
        if (_bulletQueue.Count == 0)
        {
            throw new System.Exception("la cola esta vacia");
        }
        _bulletQueue.Dequeue();
        _indice--;
    }
    
    public bool ColaVacia() //verifica que la Queue no este vacia 
    {
        return (_indice == 0);
    }

    public object Primero() //devuelve el primero 
    {
        if (_bulletQueue.Count == 0)
        {
            throw new System.Exception("la cola esta vacia");
        }
        return _bulletQueue.Peek();
    }
}