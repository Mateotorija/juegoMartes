using UnityEngine;
[System.Serializable]
public class Goblin : Monster
{
    public override void Attack()
    {
        Debug.Log($"the monster {nameof(Goblin)} is attaking");
    }

    public override void Die()
    {
        Debug.Log($"the monster {nameof(Goblin)} is dying");
    }

    public override void RunAway()
    {
        Debug.Log($"the monster {nameof(Goblin)} is running away");
    }
}
