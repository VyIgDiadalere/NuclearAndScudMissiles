using UnityEngine;

namespace Source.Scripts.View.Interfaces
{
    public interface ICameraMoverView
    {
        void ApplyMove(System.Numerics.Vector3 direction);
    }
}