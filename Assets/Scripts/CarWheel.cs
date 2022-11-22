using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarWheel : MonoBehaviour
{
    [SerializeField] private WheelCollider _wheelCollider; 

    private Vector3 _wheelPosition;
    private Quaternion _wheelRotation;

    private void Update()
    {
        _wheelCollider.GetWorldPose(out _wheelPosition, out _wheelRotation);
        transform.position = _wheelPosition;
        transform.rotation = _wheelRotation;
    }
}
