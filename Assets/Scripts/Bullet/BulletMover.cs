using UnityEngine;

namespace Bullet
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public void Update()
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }
    }
}