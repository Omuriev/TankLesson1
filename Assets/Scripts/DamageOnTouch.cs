using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private float _invulnerableValue = 1f;
    [SerializeField] private LayerMask _targetsLayer;

    [Header("Owner")]
    [SerializeField] private Health _ownerHealth;
    [SerializeField] private bool _canDamageOwner = false;
    [SerializeField] private int _selfDamageValue = 0;
    [SerializeField] private float _selfInvulnerableValue = 1;

    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks _makeDamageFeedbacks;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((_targetsLayer & 1 << other.gameObject.layer) != 1 << other.gameObject.layer)
            return;

        Health health = other.GetComponent<Health>();

        if (health)
            TryMakeDamage(health);
    }

    private void TryMakeDamage(Health targetHealth)
    {
        if (_ownerHealth == targetHealth && !_canDamageOwner)
            return;

        targetHealth.TakeDamage(_damageValue, _invulnerableValue);
        _makeDamageFeedbacks?.PlayFeedbacks();

        if (_selfDamageValue > 0 && _ownerHealth)
            _ownerHealth.TakeDamage(_selfDamageValue, _selfInvulnerableValue);
    }
}
