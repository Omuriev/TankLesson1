using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponHandleAbility _weaponHandleAbility;
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _reloadTime = 3f;

    [Header("Clip Info")]
    [SerializeField] private int _currentBulletCount = 5;
    [SerializeField] private int _maxCurrentBulletCount = 5;
    [SerializeField] private int _allBulletCount;
    [SerializeField] private int _maxBulletCount = 20;
    
    private void OnEnable()
    {
        _weaponHandleAbility.OnShotStarted += OnTryShot;
    }

    private void OnDisable()
    {
        _weaponHandleAbility.OnShotStarted -= OnTryShot;
    }

    private void OnTryShot()
    {
        if (_currentBulletCount > 0)
        {
            Shoot();
        }
        else
        {
            if (_allBulletCount > 0)
            {
                Reload();
            }
        }
    }

    private void Shoot()
    {
        Projectile bullet = Instantiate(_prefab, _shotPoint.position, _shotPoint.rotation);
        bullet.Fire(transform.forward);
        _currentBulletCount--;
    }

    private void Reload()
    {
        int numberOfBulltes = _maxCurrentBulletCount - _currentBulletCount;

        if (_allBulletCount >= numberOfBulltes)
        {
            _allBulletCount = _allBulletCount - numberOfBulltes;
            _currentBulletCount = _maxCurrentBulletCount;
        }
        else if (_allBulletCount < numberOfBulltes)
        {
            _currentBulletCount = _currentBulletCount + _allBulletCount;
            _allBulletCount = 0;
        }
    }
}
