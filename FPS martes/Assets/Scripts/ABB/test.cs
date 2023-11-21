using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    ABB2 arbol = new ABB2();

    public void AddToBT(int jugador)
    {
        arbol.AgregarElem(jugador);
    }
}
