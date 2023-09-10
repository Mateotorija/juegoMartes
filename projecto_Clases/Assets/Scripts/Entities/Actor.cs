using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{
    #region     PUBLIC_PROPERTIES
    public int MaxLife => _stats.MaxLife;

    public int CurentLife => _currentLife;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] protected ActorStats _stats;
    [SerializeField] private string actorID;

    private static IPlayerUIManagerProvider uiProvider = UIManager.Instance;
    int _currentLife;
    #endregion

    #region UNITY_EVENTS
    protected void Start()
    {
        _currentLife = MaxLife;
    }
    #endregion

    #region IDAMAGEABLE_METHODS
    public void TakeDamage(int damage, ElementalAffinity elementalAffinity = null)
    {
        _currentLife -= damage;
        Debug.Log($"{name}: Remaining life = {_currentLife}");
        uiProvider.PlayerUIManager.UpdateActorHealth(actorID, _currentLife);
        if(_currentLife <= 0)
        {
            Die();
        }
    }

    private float CalculateWeakness(ElementalAffinity affinity)
    {
        bool isWeak = affinity == _stats.Weakness;
        return isWeak ? 2 : 1;
    }

    private float CalculateResistance(ElementalAffinity affinity)
    {
        bool isResistant = affinity == _stats.Resistance;
        return isResistant ? 0.5f : 1;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    #endregion
}


