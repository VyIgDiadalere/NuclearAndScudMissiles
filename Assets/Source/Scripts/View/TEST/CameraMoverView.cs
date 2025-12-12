using System;
using Source.Scripts.Core.CoreInterfaces;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    [Serializable]
    public class CameraMoverView : MonoBehaviour, IUpdatableView
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _smoothSpeed = 1f;
        
        private IDragInputSystem _dragInputSystem;

        private bool _isInialized = false;

        public void Init(IDragInputSystem  clickInputSystem)
        {
            _dragInputSystem = clickInputSystem;
            
            _isInialized = true;
        }
        
        public void Refresh()
        {
            if (_isInialized == false)
            {
                return;
            }
            
            var move = _dragInputSystem.GetDragInputData();

            if (move.DragX != 0 || move.DragY != 0)
            {
                Vector3 targetPos = _cameraTransform.position + new Vector3(move.DragX, 0, move.DragY) * Time.deltaTime;
                _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, targetPos, _smoothSpeed);
            }
        }
    }
}