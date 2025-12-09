using Reflex.Attributes;
using Source.Scripts.Core;
using Source.Scripts.GENERAL.InputService;
using Source.Scripts.GENERAL.SelectionSystem;
using Source.Scripts.View;
using UnityEngine;

namespace Source.Scripts.GENERAL
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CameraMoverView _cameraMoverView;
        [SerializeField] private RaycasterService _raycasterService;
        [SerializeField] private MainViewPanel _mainViewPanel;
        
        private SelectionBehaviorManager _selectionBehaviorManager;
        private SelectedObjectViewHandler  _selectedObjectViewHandler;
        private CameraMoverPresenter _cameraMover;
        private CompositeDisposable _compositeDisposables = new();
        
        [Inject] private IInputService _inputService;
        
        private void Awake()
        {
            _cameraMover = new CameraMoverPresenter(_cameraMoverView, _inputService, _compositeDisposables);
            _selectedObjectViewHandler  = new SelectedObjectViewHandler(_mainViewPanel);
            _selectionBehaviorManager = new SelectionBehaviorManager(_raycasterService, _inputService, _selectedObjectViewHandler);
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