using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Circle
{
    public class CircleMover : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _minDistanceToTarget = 0.01f;

        private float _currentSpeed;

        private bool _haveTarget;
        private Vector3 _target;
        private Queue<Vector3> _points = new Queue<Vector3>();

        public float MaxSpeed => _maxSpeed;

        public float MinSpeed => _minSpeed;

        public float CurrentSpeed => _currentSpeed;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _currentSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, _target) < _minDistanceToTarget)
            {
                if(_points.Count > 0)
                {
                    _target = _points.Dequeue();
                }
                else
                {
                    _haveTarget = false;
                    enabled = false;
                }
            }
        }

        public void Init()
        {
            _currentSpeed = _startSpeed;
            _target = transform.position;
            enabled = false;
        }
        
        public void AddPoint(Vector3 point)
        {
            if(_haveTarget)
            {
                _points.Enqueue(point);
            }
            else
            {
                _haveTarget = true;
                _target = point;
                enabled = true;
            }
        }

        public void SetSpeed(float speed)
        {
            speed = Mathf.Clamp(speed, _minSpeed, _maxSpeed);
            _currentSpeed = speed;
        }

        private void OnValidate()
        {
            _startSpeed = Mathf.Clamp(_startSpeed, _minSpeed, _maxSpeed);
        }
    }
}