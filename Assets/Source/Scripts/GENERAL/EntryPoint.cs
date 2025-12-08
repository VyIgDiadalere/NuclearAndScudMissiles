using Reflex.Attributes;
using Source.Scripts.Core;
using Source.Scripts.GENERAL.InputService;
using Source.Scripts.View;
using UnityEngine;

namespace Source.Scripts.GENERAL
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CameraMoverView _cameraMoverView;
        private CameraMoverPresenter _cameraMover;
        private readonly CompositeDisposable _compositeDisposables = new();
        

        [Inject] private IInputService _inputService;


        private void Awake()
        {
            _cameraMover = new CameraMoverPresenter(_cameraMoverView, _inputService, _compositeDisposables);
        }

        private void Update()
        {
            _inputService.Update();
        }

        private void OnDestroy()
        {
            _compositeDisposables.Dispose();
        }
    }
}