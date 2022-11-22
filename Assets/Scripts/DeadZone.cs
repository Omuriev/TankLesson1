using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZone : MonoBehaviour
{
    private float _damage = 5;

    public UnityAction<float> OnHealthChanged;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Health>(out Health health))
        {
            StartCoroutine(Damage(health));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            StopCoroutine(Damage(health));
        }
    }

    private IEnumerator Damage(Health health)
    {
        while (health.HealthValue > 0)
        {
            OnHealthChanged.Invoke(_damage);
            yield return new WaitForSeconds(2);
        }
    }
}
