using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _angularSpeed = 10f;
    [SerializeField] private Transform[] _wayPoints;

    private int _currentPoint;

    private void Start()
    {
        _currentPoint = 0;
    }

    private void Update()
    {
        if (transform.position != _wayPoints[_currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentPoint].position, _speed * Time.deltaTime);
        }
        else
        {
            _currentPoint++;
        }

        if (_currentPoint == _wayPoints.Length)
        {
            _currentPoint = 0;
        }
    }
}
