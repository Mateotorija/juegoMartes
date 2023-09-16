
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public interface ColaTDA
    {
        //void InicializarCola();
        // siempre que la cola este inicializada
        void Acolar(GameObject GameObject);
        // siempre que la cola este inicializada y no este vacıa
        void Desacolar(GameObject LastBullet);
        // siempre que la cola este inicializada
        bool ColaVacia();
    // siempre que la cola este inicializada y no este vacıa
        object Primero();
    }

