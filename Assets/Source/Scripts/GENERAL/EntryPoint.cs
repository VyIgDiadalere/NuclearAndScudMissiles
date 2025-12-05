using System;
using Reflex.Attributes;
using Source.Scripts.GENERAL.InputService;
using UnityEngine;

namespace Source.Scripts.GENERAL
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        
        private CameraMover _cameraMover;
        
        [Inject] private IInputService _inputService;

        private void Awake()
        {
            _cameraMover = new CameraMover(_inputService, _cameraTransform);
        }

        private void Update()
        {
            _inputService.Update();
        }
    }
}