using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZone : MonoBehaviour
{
    private int _damage = 1;
    private bool _isInZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            _isInZone = true;
            StartCoroutine(Damage(health));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            _isInZone = false;
            StopCoroutine(Damage(health));
        }
    }

    private IEnumerator Damage(Health health)
    {
        while (health.CurrentHealth > 0 && _isInZone == true)
        {
            health.TakeDamage(_damage, 0);
            yield return new WaitForSeconds(2);
        }
    }
}
