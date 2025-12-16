using Source.Scripts.View.Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Source.Scripts.View.Spawners
{
    public class SpawnableObjectPool <T> where T : MonoBehaviour, ISpawnableObject<T>
    {
        private readonly SpawnableObjectFactory _factory;
        private readonly T _prefab;
        private ObjectPool<T> _pool;
        private readonly int _poolCapacity = 15;
        private readonly int _poolMaxSize = 50;

        public SpawnableObjectPool(SpawnableObjectFactory factory, T prefab)
        {
            _factory = factory;
            _prefab = prefab;
            CreatePool();
        }

        public T EnableObject(Vector3 position)
        {
            T currentObject = _pool.Get();
            currentObject.transform.position = position;
            currentObject.Disabled += ReleasedObject;

            return currentObject;
        }

        private void CreatePool()
        {
            _pool = new ObjectPool<T>(
                createFunc: () => CreateObject(),
                actionOnGet: (item) => Initialize(item),
                actionOnRelease: (item) => item.gameObject.SetActive(false),
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize);
        }

        private T CreateObject()
        {
            T item = _factory.GetNewSpawnableObject(_prefab);

            return item;
        }

        private void Initialize(T item)
        {
            item.gameObject.SetActive(true);
        }

        private void ReleasedObject(T item)
        {
            item.Disabled -= ReleasedObject;
            _pool.Release(item);
        }
    }
}