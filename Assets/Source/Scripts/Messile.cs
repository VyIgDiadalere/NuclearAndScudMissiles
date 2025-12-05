using System;
using UnityEngine;

namespace Source.Scripts
{
    public class Messile : MonoBehaviour
    {
        [SerializeField] private Curve _curve;
        [SerializeField] private float _speed;
        [SerializeField] private float _additionalSpeed = 0.01f;
        [SerializeField] private float _maxHeightOffset = 2;

        private float _currentTime;
        private float _tempHeight;
        private float _currentHeight;
        private float _maxHeight;

        private void Update()
        {
            _tempHeight = _currentHeight;
            _currentTime += Time.deltaTime * _speed;

            transform.position = _curve.Evaluate(_currentTime);
            transform.forward = _curve.Evaluate(_currentTime + 0.001f) - transform.position;
            
            _currentHeight = transform.position.y;

            if (_currentHeight < _tempHeight)
            {
                if (_maxHeight == 0)
                {
                    _maxHeight = _currentHeight;
                }

                if (_currentHeight < _maxHeight - _maxHeightOffset)
                {
                    _speed += _additionalSpeed;
                }
            }
            
            if (_currentTime >= 1)
            {
                Destroy(gameObject);
            }
        }
    }
}