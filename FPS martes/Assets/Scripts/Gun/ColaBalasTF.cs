using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ColaBalasTF : ColaTDA
    {
        int[] ColaBalas; // arreglo en donde se guarda la informacion
        int indice; // variable entera en donde se guarda la cantidad de elementos que se tienen guardados

        public void InicializarCola()
        {
        ColaBalas = new int[100];
            indice = 0;
        }

        public void Acolar(GameObject x)
        {
            for (int i = indice - 1; i >= 0; i--)
            {
            ColaBalas[i + 1] = ColaBalas[i];
            }
        //ColaBalas[0] = x;
            
            indice++;
        }
        public void Desacolar()
        {
            indice--;
        }

        public bool ColaVacia()
        {
            return (indice == 0);
        }

        public int Primero()
        {
            return ColaBalas[indice - 1];
        }
    }

