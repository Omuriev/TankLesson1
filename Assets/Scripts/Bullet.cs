using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _bulletSpeed;

    private float _startTime;
    private float _destructionTime = 5f;

    private void Update()
    {
        DestroyBullet();
    }

    public void Fire(Vector3 forwardValue)
    {
        _rigidbody.velocity = forwardValue * _bulletSpeed;
    }

    private void DestroyBullet()
    {
        _startTime += Time.deltaTime;

        if (_startTime >= _destructionTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
