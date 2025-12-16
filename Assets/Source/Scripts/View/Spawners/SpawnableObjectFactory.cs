using Source.Scripts.View.Interfaces;
using UnityEngine;

namespace Source.Scripts.View.Spawners
{
    public class SpawnableObjectFactory
    {
        public T GetNewSpawnableObject<T>(T prefab) where T : MonoBehaviour, ISpawnableObject<T>
        {
            return Object.Instantiate(prefab);
        }
    }
}