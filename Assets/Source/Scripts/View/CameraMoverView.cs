using Source.Scripts.GENERAL.Extensions;
using Source.Scripts.View.Interfaces;
using UnityEngine;

namespace Source.Scripts.View
{
    public class CameraMoverView : MonoBehaviour,ICameraMoverView
    {
        [SerializeField] private Transform _cameraTransform;

        public void ApplyMove(System.Numerics.Vector3 delta)
        {
            var unityDelta = delta.ToUnityEngineVector3();
            Vector3 targetPosition = _cameraTransform.position + unityDelta;
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, targetPosition, Time.deltaTime);
        }
    }
}