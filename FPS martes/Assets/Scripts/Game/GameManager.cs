using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gun Gun;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        Time.timeScale = 0f;
        Gun.CanShoot = false;
    }
}