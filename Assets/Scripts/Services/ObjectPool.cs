using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private int _capacity;

        private List<GameObject> _pool = new();

        public void Init(GameObject prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(prefab, _container);
                spawned.SetActive(false);

                _pool.Add(spawned);
            }
        }

        public void Init(GameObject[] prefabs)
        {
            for (int i = 0; i < _capacity; i++)
            {
                int randomIndex = Random.Range(0, prefabs.Length);
                GameObject spawned = Instantiate(prefabs[randomIndex], _container);
                spawned.SetActive(false);

                _pool.Add(spawned);
            }
        }

        public bool TryGetObject(out GameObject resualt)
        {
            resualt = _pool.FirstOrDefault(p => p.activeSelf == false);

            return resualt != null;
        }
    }
}