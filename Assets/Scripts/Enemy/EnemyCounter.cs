using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemy
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies;

        private void OnEnable()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Killed += OnKilled;
            }
        }

        private void OnDisable()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Killed -= OnKilled;
            }
        }

        private void OnKilled()
        {
            List<Enemy> disabledEnemies = new List<Enemy>();

            foreach (var enemy in _enemies)
            {
                if (enemy.gameObject.activeSelf == false)
                {
                    disabledEnemies.Add(enemy);
                }
            }

            if (disabledEnemies.Count == _enemies.Count)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}