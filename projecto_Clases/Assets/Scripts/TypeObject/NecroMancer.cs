using UnityEngine;
[System.Serializable]
public class NecroMancer : Monster
{
    public override void Attack()
    {
        Debug.Log($"the monster {nameof(NecroMancer)} is attaking");
    }

    public override void Die()
    {
        Debug.Log($"the monster {nameof(NecroMancer)} is dying");
    }

    public override void RunAway()
    {
        Debug.Log($"the monster {nameof(NecroMancer)} is running away");
    }
}
