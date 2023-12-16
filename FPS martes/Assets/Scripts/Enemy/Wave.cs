using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    // prefab del enemigo cantidad y que tan rapido spawneen

    public List<GameObject> enemies;
    public int count;
    public float rate;
}
