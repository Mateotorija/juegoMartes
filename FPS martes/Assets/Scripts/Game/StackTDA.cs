using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StackTDA<T>
{
    void InitPila(); // Inicializar pila
    void Stack(T item); // Apilar
    void Unstack(); // Desapilar
    bool EmptyStack(); // Pila vacia
    T Top(); // Tope
}
