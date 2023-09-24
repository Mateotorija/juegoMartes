using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StackTDA
{
    void InitPila(); // Inicializar pila
    void Stack(Wave item); // Apilar
    void Unstack(); // Desapilar
    bool EmptyStack(); // Pila vacia
    Wave Top(); // Tope
}
