using Configs;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHullMovement : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        private Rigidbody2D _rigidbody;
        private PlayerConfig _config;

        [Inject]
        private void Init(PlayerConfig config)
        {
            _config = config;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = (Vector2)transform.up * GetBodyMovement().y * _config.Speed * Time.fixedDeltaTime;
            _rigidbody.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -GetBodyMovement().x * _config.RotationSpeed * Time.fixedDeltaTime));
        }

        private Vector2 GetBodyMovement()
        {
            Vector2 movementDirection = new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
            return movementDirection.normalized;
        }
    }
}