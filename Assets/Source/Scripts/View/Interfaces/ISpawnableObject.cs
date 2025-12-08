using System;
using UnityEngine;

namespace Source.Scripts.View.Interfaces
{
    public interface ISpawnableObject <T> where T : MonoBehaviour
    {
        event Action<T> Disabled;
        
                void Disable();
    }
}