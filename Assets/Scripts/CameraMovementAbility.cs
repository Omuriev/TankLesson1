using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovementAbility : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private float _minY = -30f;
    [SerializeField] private float _maxY = 30f;

    [Header("Objects")]
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _tower;

    private float _xRotation = 0f;

    void Start()
    { 
        //Отключает мышку
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _minY, _maxY);
        
        _camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _tower.Rotate(Vector3.up * mouseX);
    }
}