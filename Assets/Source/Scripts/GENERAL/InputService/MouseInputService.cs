using UniRx;
using UnityEngine;

namespace Source.Scripts.GENERAL.InputService
{
    public class MouseInputService : IInputService
    {
        private const int LeftMouseButtonIndex = 0;
        
        private float _dragThreshold = 10f;
        private float _tapTimeThreshold = 0.3f;
        private Vector2 _startPos;
        private Vector2 _previousPos;
        private float _startTime;
        private bool _isDragging;
        private bool _isActiveInput = true;
        private float _mouseSensitivity = 50f;
        
        public ReactiveProperty<bool> IsTouching { get; private set; } = new ReactiveProperty<bool>();
        public ReactiveProperty<Vector2> CurrentTouchPosition { get; private set; } = new ReactiveProperty<Vector2>();
        public ReactiveProperty<Vector2> MovementDelta { get; private set; } = new ReactiveProperty<Vector2>();
        public ReactiveProperty<Vector2> ReleasePoint { get; private set; } = new ReactiveProperty<Vector2>();
        
        public void Enable()
        {
            _isActiveInput = true;
        }

        public void Disable()
        {
            _isActiveInput =  false;
        }

        public void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            bool isMouseDown = Input.GetMouseButtonDown(LeftMouseButtonIndex);
            bool isMouseUp = Input.GetMouseButtonUp(LeftMouseButtonIndex);
            bool isMousePressed = Input.GetMouseButton(LeftMouseButtonIndex);

            IsTouching.Value = isMousePressed;

            Vector2 mousePos = Input.mousePosition;
            CurrentTouchPosition.Value = mousePos;
            
            if (!_isActiveInput) return;

            if (isMouseDown)
            {
                _startPos = mousePos;
                _previousPos = mousePos;
                _startTime = Time.time;
                _isDragging = false;
                MovementDelta.Value = Vector2.zero;
            }
            
            if (isMousePressed)
            {
                Vector2 currentDelta = (mousePos - _previousPos) * _mouseSensitivity;
                float totalDistance = Vector2.Distance(_startPos, mousePos);
                
                if (!_isDragging && totalDistance > _dragThreshold)
                {
                    _isDragging = true;
                }
                
                MovementDelta.Value = _isDragging ? currentDelta : Vector2.zero;
            }
            else
            {
                MovementDelta.Value = Vector2.zero;
            }

            if (isMouseUp)
            {
                float duration = Time.time - _startTime;
                
                if (!_isDragging && duration <= _tapTimeThreshold)
                {
                    ReleasePoint.Value = mousePos;
                }

                _isDragging = false;
                MovementDelta.Value = Vector2.zero;
            }
            
            _previousPos = mousePos;
        }
    }
}