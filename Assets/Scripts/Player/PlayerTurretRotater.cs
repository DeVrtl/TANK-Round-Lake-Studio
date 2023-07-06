using Configs;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerTurretRotater : MonoBehaviour
    {
        private PlayerConfig _config;
        private Camera _main;

        private void Awake()
        {
            _main = Camera.main;
        }

        [Inject]
        private void Init(PlayerConfig settings)
        {
            _config = settings;
        }

        private void Update()
        {
            Vector3 turretDirection = (Vector3)GetMousePosition() - transform.position;

            float desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
            float rotationStep = _config.TurretRotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationStep);
        }

        private Vector2 GetMousePosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _main.nearClipPlane;
            Vector2 mouseWorldPosition = _main.ScreenToWorldPoint(mousePosition);
            return mouseWorldPosition;
        }
    }
}