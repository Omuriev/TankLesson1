using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _directionOffset = 5;

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector3 direction = _camera.transform.forward * _directionOffset;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
