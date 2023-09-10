using UnityEngine;
[System.Serializable]
public class Dragon : Monster
{
    public override void Attack()
    {
        Debug.Log($"the monster {nameof (Dragon)} is attaking");
    }

    public override void Die()
    {
        Debug.Log($"the monster {nameof(Dragon)} is dying");
    }

    public override void RunAway()
    {
        Debug.Log($"the monster {nameof(Dragon)} is running away");
    }
}
