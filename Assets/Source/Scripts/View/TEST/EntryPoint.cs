using System;
using Source.Scripts.Core;
using Source.Scripts.View.Systems.SelectionSystem;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    [Serializable]
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private InputView _inputView;
        [SerializeField] private SelectionUpdaterView _selectionUpdaterView;
        [SerializeField] private ViewRaycasterService _raycasterService;
        [SerializeField] private CameraMoverView _cameraMoverView;

        private ViewHub _viewHub;
        private CoreWorld _coreWorld;
        private CoreSystems _coreSystems;

        void Awake()
        {
            _coreWorld = new CoreWorld();
            _coreSystems = new CoreSystems(_coreWorld);
            _viewHub  = new ViewHub();
            
            _inputView.Init(_coreSystems.ClickInputSystem, _coreSystems.DragInputSystem);
            _selectionUpdaterView.Init(_coreSystems.SelectionSystem, _coreSystems.ClickInputSystem, _raycasterService);
            _cameraMoverView.Init(_coreSystems.DragInputSystem);
            
            _viewHub.RegisterView(_inputView);
            _viewHub.RegisterView(_selectionUpdaterView);
            _viewHub.RegisterView(_cameraMoverView);
        }

        void Update()
        {
            _viewHub.UpdateViews();
            _coreSystems.UpdateCore();
        }
    }
}