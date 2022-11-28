using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealthValue = 3;
    [SerializeField] private int _initializeHealthValue = 3;

    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks _takeDamageFeedbacks;
    [SerializeField] private MMFeedbacks _dieFeedbacks;

    private int _currentHealth;
    private bool _isInvulnerable = false;
    private bool _isAlive = true;
    private Coroutine _invulnerableCoroutine;

    public int CurrentHealth => _currentHealth;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        SetHealth(_initializeHealthValue);
    }

    private void SetHealth(int value)
    {
        if (value > _maxHealthValue)
        {
            value = _maxHealthValue;
        }

        _currentHealth = value;
    }

    public void TakeDamage(int damageValue, float invulnerableTime)
    {
        if (_isInvulnerable || !_isAlive || _currentHealth <= 0)
            return;

        Debug.Log($"{gameObject.name} получил {damageValue} урона");
        _currentHealth -= damageValue;
        _takeDamageFeedbacks?.PlayFeedbacks();
        CheckDeathCondition();

        if (invulnerableTime > 0)
        {
            if (_invulnerableCoroutine != null)
                StopCoroutine(_invulnerableCoroutine);

            _invulnerableCoroutine = StartCoroutine(StartInvulnerableTimer(invulnerableTime));
        }
            
    }

    private void CheckDeathCondition()
    {
        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        _dieFeedbacks?.PlayFeedbacks();
        _isAlive = false;
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    private IEnumerator StartInvulnerableTimer(float invulnerableTime)
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(invulnerableTime);
        _isInvulnerable = false;
    }
}
