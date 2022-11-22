using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealthValue;
    [SerializeField] private GameObject _dieExplosionEffect;
    [SerializeField] private DeadZone _deadZone;
    public float HealthValue { get; private set; }

    private void OnEnable()
    {
        _deadZone.OnHealthChanged += TakeDamage;
    }

    private void OnDisable()
    {
        _deadZone.OnHealthChanged += TakeDamage;
    }

    private void Start()
    {
        HealthValue = _maxHealthValue;
    }

    public void TakeDamage(float damageValue)
    {
        HealthValue -= damageValue;

        if (HealthValue <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(_dieExplosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
