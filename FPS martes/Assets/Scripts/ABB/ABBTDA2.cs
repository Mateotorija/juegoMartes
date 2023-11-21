using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ABBTDA2
{
    int Raiz();
    ABBTDA2 HijoIzq();
    ABBTDA2 HijoDer();
    bool ArbolVacio();
    void InicializarArbol();
    void AgregarElem(int x);
    void EliminarElem(int x);
}