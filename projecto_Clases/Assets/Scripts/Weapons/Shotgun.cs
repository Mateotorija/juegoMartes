using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour,  IWeapon
{
    #region IWEAPON_PROPERTIES
    public GameObject Bullet => _bullet;

    public int Damage => _damage;

    public int MagSize => _magSize;

    public WeaponStats WeaponStats => throw new System.NotImplementedException();
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private GameObject _bullet;

    [SerializeField] private int _magSize = 9;
    [SerializeField] private int _bulletsPerShot = 10;
    [SerializeField] private int _bulletCount;

    [SerializeField] private int _damage = 5;
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
            for (int i = 0; i < _bulletsPerShot; i++)
            {
                GameObject bullet = Instantiate(_bullet, transform.position + Random.insideUnitSphere * 1, Quaternion.identity);
                bullet.GetComponent<BasicBullet>().SetOwner(this);
            }
            _bulletCount--;
        }
    }

    public void Reload() => _bulletCount = _magSize;

    public bool HasSpecialAttack() => false;

    public void SpecialAttack() => Debug.Log("Special Atack");
    #endregion
}
