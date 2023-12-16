using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaMovimientoEnGrafo : MonoBehaviour
{
    public PruebaGrafo mapa;
    private int nodoActual = 0;
    private bool enObjetivo = false;
    [SerializeField] private int velocity = 0;    

    // Update is called once per frame
    void Update()
    {
        if (enObjetivo == false)
        {
            Vector3 nodoObjetivo = new Vector3(mapa.nodosCoords[mapa.ruta[nodoActual]].x + 0.5f, 0.5f, mapa.nodosCoords[mapa.ruta[nodoActual]].z + 0.5f);

            if (Vector3.Magnitude(transform.position - nodoObjetivo) < 0.1)
            {
                nodoActual++;
                if(nodoActual == mapa.ruta.Count)
                {
                    enObjetivo = true;
                }
            }

            transform.LookAt(nodoObjetivo);
            transform.Translate(Vector3.forward * Time.deltaTime * velocity);
        }
    }
}
