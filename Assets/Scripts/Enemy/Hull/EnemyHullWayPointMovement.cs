using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Configs;

namespace Enemy.Hull
{
    public class EnemyHullWayPointMovement : MonoBehaviour
    {
        [SerializeField] private Transform _path;

        private EnemyConfig _config;
        private List<Transform> _points;
        private int _currentPoint;

        private void Start()
        {
            _points = new List<Transform>(_path.childCount);
            _path.transform.GetComponentsInChildren(_points);
            _points.Remove(_path.transform);
        }

        [Inject]
        private void Init(EnemyConfig config)
        {
            _config = config;
        }

        private void Update()
        {
            Transform target = _points[_currentPoint];

            MoveForward(target);
            Rotate(target);

            UpdateTargetPoint(target);
        }

        private void UpdateTargetPoint(Transform target)
        {
            if (transform.position == target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Count)
                {
                    _currentPoint = 0;
                }
            }
        }

        private void Rotate(Transform target)
        {
            Vector3 direction = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }

        private void MoveForward(Transform target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _config.HullSpeed * Time.deltaTime);
        }
    }
}