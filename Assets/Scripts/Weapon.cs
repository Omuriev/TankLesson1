using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _reloadTime = 0.5f;
    [SerializeField] private float _timeBetweenShoot = 0.7f;

    [Header("Clip Info")]
    [SerializeField] private int _maxClip = 1;

    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks _shootFeedbacks;
    
    private int _currentBulletCount;
    private bool _canShoot = true;
    private bool _isSemiAutomatic = true;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _currentBulletCount = _maxClip;
    }

    public void InputFiringMode(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            _isSemiAutomatic = _isSemiAutomatic ? false : true;
        
    }

    public void OnTryShoot()
    {
        if (_canShoot && _isSemiAutomatic)
        {
            StartCoroutine(WaitBeforeShoot());
            Shoot();
        }
        else if (_canShoot && !_isSemiAutomatic)
        {
            Shoot();
        }
            
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

    private IEnumerator WaitBeforeShoot()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_timeBetweenShoot);
        _canShoot = true;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);
        _canShoot = true;
        _currentBulletCount = _maxClip;
    }
}
