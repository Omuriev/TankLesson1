using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _angularSpeed = 10f;
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _inputDirection;
    
    private void FixedUpdate()
    {
        Move();
        Rotation();
    }

    public void InputDirection(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        _inputDirection = new Vector3(inputValue.x, 0f, inputValue.y);
    }

    private void Move()
    {
        if (_inputDirection.z == 0)
            return;

        Vector3 direction = new Vector3(0, 0, _inputDirection.z);
        _rigidbody.AddRelativeForce(_speed * direction * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void Rotation()
    {
        if (_inputDirection.x == 0)
            return;

        Vector3 rotationDirection = new Vector3(0, _inputDirection.x, 0);
        _rigidbody.angularVelocity = rotationDirection * _angularSpeed * Time.fixedDeltaTime;
    }

}
