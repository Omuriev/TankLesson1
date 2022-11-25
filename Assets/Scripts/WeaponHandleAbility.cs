using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class WeaponHandleAbility : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;

    public UnityAction OnShotStarted;

    public void GetButtonClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (_currentWeapon)
            {
                OnShotStarted.Invoke();
            }
        }
    }
}