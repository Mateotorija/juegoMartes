using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    #region PROPERTIES

    WeaponStats WeaponStats { get; }
    GameObject Bullet { get; }
    int Damage { get; }
    int MagSize { get; }
    #endregion

    #region METHODS
    void Attack();
    void Reload();
    bool HasSpecialAttack();
    void SpecialAttack();
    #endregion
}
