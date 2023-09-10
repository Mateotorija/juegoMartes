using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet : IProduct
{
    #region PROPERTIES
    float LifeTime { get; }
    LayerMask HitteableLayer { get; }
    IWeapon Owner { get; }
    #endregion

    #region METHODS
    void Init();
    void SetOwner(IWeapon owner);
    void OnTriggerEnter(Collider other);
    #endregion
}
