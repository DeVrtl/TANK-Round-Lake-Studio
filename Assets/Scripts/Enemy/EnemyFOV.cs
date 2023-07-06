using UnityEngine;
using Zenject;
using Configs;

namespace Enemy
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyFOV : MonoBehaviour
    {
        private EnemyConfig _config;
        private CircleCollider2D _fov;

        public Transform Target { get; private set; }

        private void Awake()
        {
            _fov = GetComponent<CircleCollider2D>();

            _fov.radius = _config.FovRadius;
        }

        [Inject]
        private void Init(EnemyConfig config)
        {
            _config = config;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Player.Player player))
            {
                Target = player.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Player.Player player))
            {
                Target = null;
            }
        }
    }
}