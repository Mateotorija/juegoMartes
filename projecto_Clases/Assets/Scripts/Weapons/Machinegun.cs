using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : MonoBehaviour, IWeapon
{
    #region IWEAPON_PROPERTIES
    public GameObject Bullet => _weaponStats.Bullet;

    public int Damage => _weaponStats.Damage;

    public int MagSize => _weaponStats.MagSize;

    public WeaponStats WeaponStats => _weaponStats;
    #endregion

    #region PRIVATE_PROPERTIES
   
    [SerializeField] private int _bulletCount;

    [SerializeField] MachineGunStats _weaponStats;
    #endregion

    #region UNITY_EVENTS
    private void Start()
    {
        Reload();
    }
    #endregion

    #region IWEAPON_METHODS
    public void Attack()
    {
        if(_bulletCount > 0)
        {
            for (int i = 0; i < _weaponStats.BulletsPerShot; i++)
            {
                GameObject bullet = Instantiate(_weaponStats.Bullet, transform.position - Vector3.forward * i / 10, Quaternion.identity);
                bullet.GetComponent<BasicBullet>().SetOwner(this);
            }
            _bulletCount--;
        }
    }

    public void Reload() => _bulletCount = _weaponStats.MagSize;

    public bool HasSpecialAttack() => false;

    public void SpecialAttack() => Debug.Log("Special Atack");
    #endregion
}
