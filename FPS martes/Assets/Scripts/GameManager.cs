using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gun Gun;
    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }
    public void Init()
    {
        Time.timeScale = 0f;
        Gun.CanShoot = false;
    }
}
