using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class WeaponHandleAbility : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;

    public void GetButtonClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (_currentWeapon)
            {
                _currentWeapon.OnTryShoot();
            }
        }
    }
}