using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Monster: MonoBehaviour
{
    public int Health;
    public abstract void Attack();

    public abstract void Die();

    public abstract void RunAway();

}
