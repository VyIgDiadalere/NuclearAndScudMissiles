using Source.Scripts.Core.CoreInterfaces;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    public class InputView : MonoBehaviour, IUpdatableView
    {
        private const float DragThreshold = 10f;
        private const float DragSpeed = 20f;

        private IDragInputSystem _dragInputSystem;
        private IClickInputSystem _clickInputSystem;
        private Vector2 _startPos;
        private Vector2 _prevPos;
        private bool _isDragging;

        private bool _isInitialized = false;

        public void Init( IClickInputSystem clickInputSystem, IDragInputSystem dragInputSystem )
        {
            _clickInputSystem = clickInputSystem;
            _dragInputSystem = dragInputSystem;

            _isInitialized = true;
        }

        public void Refresh()
        {
            if (_isInitialized == false)
            {
                return;
            }
            
            Vector2 mousePos = Input.mousePosition;
            bool mousePressed = Input.GetMouseButton(0);
    
            if (Input.GetMouseButtonDown(0))
            {
                _startPos = mousePos;
                _prevPos = mousePos;
                _isDragging = false;
                
                _clickInputSystem.SetClickData(true, mousePos.x, mousePos.y );
            }
            else
            {
                _clickInputSystem.ResetClickData();
            }

            if (mousePressed)
            {
                Vector2 delta = mousePos - _prevPos;

                if (!_isDragging && delta.magnitude > DragThreshold)
                    _isDragging = true;
                
                float dragX = delta.x * DragSpeed;
                float dragY = delta.y * DragSpeed;

                _dragInputSystem.SetDragData(dragX, dragY);
            }
            else
            {
                _dragInputSystem.ResetDragData();
            }

            _prevPos = mousePos;
        }
    }
}