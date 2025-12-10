/*using Source.Scripts.GENERAL.Extensions;
using UnityEngine;

namespace Source.Scripts.GENERAL.InputService
{
    public class MouseInputService : IInputService
    {
        private const int LeftMouseButtonIndex = 0;
        private const float DragThreshold = 10f;
        private const float TapTimeThreshold = 0.3f;
        private const float MouseSensitivity = 50f;
        
        private readonly ReactiveProperty<bool> _isTouching = new ReactiveProperty<bool>();
        private readonly ReactiveProperty<System.Numerics.Vector2> _currentTouchPosition = new ReactiveProperty<System.Numerics.Vector2>();
        private readonly ReactiveProperty<System.Numerics.Vector2> _movementDelta  = new ReactiveProperty<System.Numerics.Vector2>();
        private readonly ReactiveProperty<System.Numerics.Vector2> _releasePoint  = new ReactiveProperty<System.Numerics.Vector2>();

        private Vector2 _startPos;
        private Vector2 _previousPos;
        private float _startTime;
        private bool _isDragging;
        private bool _isActiveInput = true;
        
        public IReadOnlyReactiveProperty<bool> IsTouching  => _isTouching;
        public IReadOnlyReactiveProperty<System.Numerics.Vector2> CurrentTouchPosition => _currentTouchPosition;
        public IReadOnlyReactiveProperty<System.Numerics.Vector2> MovementDelta => _movementDelta;
        public IReadOnlyReactiveProperty<System.Numerics.Vector2> ReleasePoint => _releasePoint;

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

            _isTouching.Value = isMousePressed;

            Vector2 mousePos = Input.mousePosition;
            _currentTouchPosition.Value = mousePos.ToNumericsVector2();
            
            if (!_isActiveInput) return;

            if (isMouseDown)
            {
                _startPos = mousePos;
                _previousPos = mousePos;
                _startTime = Time.time;
                _isDragging = false;
                _movementDelta.Value = Vector2.zero.ToNumericsVector2();
            }
            
            if (isMousePressed)
            {
                Vector2 currentDelta = (mousePos - _previousPos) * MouseSensitivity;
                float totalDistance = Vector2.Distance(_startPos, mousePos);
                
                if (!_isDragging && totalDistance > DragThreshold)
                {
                    _isDragging = true;
                }
                
                _movementDelta.Value = _isDragging ? currentDelta.ToNumericsVector2() : Vector2.zero.ToNumericsVector2();
            }
            else
            {
                _movementDelta.Value = Vector2.zero.ToNumericsVector2();
            }

            if (isMouseUp)
            {
                float duration = Time.time - _startTime;
                
                if (!_isDragging && duration <= TapTimeThreshold)
                {
                    _releasePoint.Value = mousePos.ToNumericsVector2();
                }

                _isDragging = false;
                _movementDelta.Value = Vector2.zero.ToNumericsVector2();
            }
            
            _previousPos = mousePos;
        }
    }
}*/