using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private GameObject _shotEffect;
    [SerializeField] private float _delayInSeconds = 3;

    private bool _canShoot = true;
    
    public void GetButtonValue(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && _canShoot == true)
        {
            Projectile newBullet = Instantiate(_prefab, transform.position, transform.rotation);
            _canShoot = false;
            newBullet.Fire(transform.forward);
            Instantiate(_shotEffect, transform.position, transform.rotation);

            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_delayInSeconds);
        _canShoot = true;
    }
}
