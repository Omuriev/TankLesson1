using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _reloadTime = 0.5f;

    [Header("Clip Info")]
    [SerializeField] private int _maxClip = 1;

    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks _shootFeedbacks;
    
    private int _currentBulletCount;
    private bool _canShoot = true;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _currentBulletCount = _maxClip;
    }

    public void OnTryShoot()
    {
        if (_canShoot)
            Shoot();
    }

    private void Shoot()
    {
        Projectile bullet = Instantiate(_prefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        bullet.Fire(transform.forward);
        _shootFeedbacks?.PlayFeedbacks();
        _currentBulletCount--;

        CheckReload();
    }

    private void CheckReload()
    {
        if (_currentBulletCount == 0)
        {
            StartCoroutine(Reload());
            _canShoot = false;
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);
        _canShoot = true;
        _currentBulletCount = _maxClip;
    }
}
