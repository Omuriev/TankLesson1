using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _bulletSpeed;

    public void Fire(Vector3 forwardValue)
    {
        _rigidbody.velocity = forwardValue * _bulletSpeed;
    }
}
