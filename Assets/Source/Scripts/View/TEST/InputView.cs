using System;
using Source.Scripts.Core.TEST;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    public class InputView : MonoBehaviour
    {
        private const float DragThreshold = 10f;
        private const float DragSpeed = 20f;
        
        private CoreWorld _world;
        private Vector2 _startPos;
        private Vector2 _prevPos;
        private bool _isDragging;

        public void Init(CoreWorld world)
        {
            _world = world;
        }
        
        private void Update()
        {
            ref var input = ref _world.InputData;

            Vector2 mousePos = Input.mousePosition;
            bool mousePressed = Input.GetMouseButton(0);
    
            if (Input.GetMouseButtonDown(0))
            {
                _startPos = mousePos;
                _prevPos = mousePos;
                _isDragging = false;
                
                input.Click = true;
                input.XPosition = mousePos.x;
                input.YPosition = mousePos.y;
            }

            if (mousePressed)
            {
                Vector2 delta = mousePos - _prevPos;

                if (!_isDragging && delta.magnitude > DragThreshold)
                    _isDragging = true;

                input.IsDragging = _isDragging;
                input.DragX = delta.x * DragSpeed;
                input.DragY = delta.y * DragSpeed;
            }
            else
            {
                input.IsDragging = false;
                input.DragX = 0;
                input.DragY = 0;
            }

            _prevPos = mousePos;
        }
    }
}