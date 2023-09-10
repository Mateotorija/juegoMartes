using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public GameObject jugador;
    public GameObject Camara;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camara.transform.position = jugador.transform.position;
        Camara.transform.rotation = jugador.transform.rotation;
    }
}
