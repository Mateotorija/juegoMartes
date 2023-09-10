using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    #region PROPERTIES
    int MaxLife { get; }
    int CurentLife { get; }
    #endregion

    #region METHODS
    void TakeDamage(int damage, ElementalAffinity elementalAffinity = null);
    void Die();
    #endregion
}
