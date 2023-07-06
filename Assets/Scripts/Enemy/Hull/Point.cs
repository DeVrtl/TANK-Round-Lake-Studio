using UnityEngine;

namespace Enemy
{
    public class Point : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _circleTrigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                transform.position = GetRandomPositionInCircle();
            }
        }

        private Vector3 GetRandomPositionInCircle()
        {
            return Random.insideUnitCircle + new Vector2(_circleTrigger.transform.position.x, _circleTrigger.transform.position.y);
        }
    }
}