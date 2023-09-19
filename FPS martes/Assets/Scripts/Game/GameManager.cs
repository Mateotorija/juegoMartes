using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gun Gun;

    public bool LoopShouldEnd;

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

    IEnumerator GameLoop()
    {
        while (LoopShouldEnd == false)
        {
            //Spawn Targets
            //Move Targets
            //Damage Targets
            //Remove Targets
            //

            yield return null;
        }
    }
}
