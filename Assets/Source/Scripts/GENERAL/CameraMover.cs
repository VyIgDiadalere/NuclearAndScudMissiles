using Source.Scripts.GENERAL.InputService;
using UniRx;
using UnityEngine;

namespace Source.Scripts.GENERAL
{
    public class CameraMover
    {
        private IInputService _inputService;
        private float _smoothSpeed = 0.1f;
        private Transform _cameraTransform;

        private Vector3 _desiredPosition;

        public CameraMover(IInputService inputService, Transform target)
        {
            _inputService  = inputService;
            _cameraTransform = target;
            
            _inputService.MovementDelta.AsObservable().Where(delta => delta != Vector2.zero).Subscribe(delta => Move(delta));
        }

        private void Move(Vector2 delta)
        {
            Vector3 move = new Vector3(-delta.x, 0, -delta.y) * _smoothSpeed;
            Vector3 targetPosition = _cameraTransform.position + move;
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, targetPosition, Time.deltaTime);
        }
    }
}