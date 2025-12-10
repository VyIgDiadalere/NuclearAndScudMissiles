using Reflex.Attributes;
using Source.Scripts.Core;
using Source.Scripts.GENERAL.InputService;
using Source.Scripts.View;
using UnityEngine;

namespace Source.Scripts.GENERAL
{
    public class EntryPoint : MonoBehaviour
    {
        
        [Inject] private IInputService _inputService;
        
        private void Awake()
        {
            
        }

        private void Update()
        {
            _inputService.Update();
        }

        private void OnDestroy()
        {
            
        }
    }
}