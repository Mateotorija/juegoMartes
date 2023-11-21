using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsCount : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private int _bullets;
    [SerializeField] private int _magSize;
    [SerializeField] private TMP_Text _bulletText;

    private void Awake()
    {
        _magSize = _gun.MagSize;
        _bullets = _magSize;
    }
    private void Update()
    {
        UpdateBullets();
    }
    public void ShootBullet()
    {
        if(_bullets <= _magSize && _bullets > 0)
            _bullets--;
    }
    public void Reloaded()
    {
        _bullets = _magSize;
    }
    public void UpdateBullets()
    {
        _bulletText.text = _bullets.ToString("0") + "/7";
    }
}
