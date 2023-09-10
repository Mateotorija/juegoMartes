using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    #region IWEAPON_PROPERTIES
    public GameObject Bullet => _weaponStats.Bullet;

    public int Damage => _weaponStats.Damage;

    public int MagSize => _weaponStats.MagSize;

    public WeaponStats WeaponStats => _weaponStats;
    #endregion

    #region PRIVATE_PROPERTIES

    [SerializeField] private WeaponStats _weaponStats;
    [SerializeField] private int _bulletCount;
    private BulletFactory bulletFactory;
    #endregion

    #region UNITY_EVENTS
    private void Start()
    {
        BasicBullet bullet = _weaponStats.Bullet.GetComponent<BasicBullet>();
        bulletFactory = new BulletFactory(bullet);
        Reload();
    }
    #endregion

    #region IWEAPON_METHODS
    public void Attack()
    {
        if (_bulletCount > 0)
        {
            IProduct bullet = bulletFactory.CreateProduct();
            GameObject bulletObject = bullet.MyGameObject;
            bulletObject.GetComponent<BasicBullet>().SetOwner(this);
            _bulletCount--;
        }
    }
    public void Reload() => _bulletCount = _weaponStats.MagSize;

    public bool HasSpecialAttack() => false;

    public void SpecialAttack() => Debug.Log("Special Atack");
    #endregion
}
