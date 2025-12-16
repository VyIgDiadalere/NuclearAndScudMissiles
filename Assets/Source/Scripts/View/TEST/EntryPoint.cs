using System;
using Source.Scripts.Core;
using Source.Scripts.View.Configs;
using Source.Scripts.View.Systems.SelectionSystem;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    [Serializable]
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ConfigRepository _configRepository;
        [SerializeField] private InputView _inputView;
        [SerializeField] private SelectionUpdaterView _selectionUpdaterView;
        [SerializeField] private ViewRaycasterService _raycasterService;
        [SerializeField] private CameraMoverView _cameraMoverView;

        private UpdatableViewHub _updatableViewHub;
        private DataHolder _dataHolder;
        private CoreSystems _coreSystems;

        void Awake()
        {
            _dataHolder = new DataHolder();
            _coreSystems = new CoreSystems(_dataHolder);
            _updatableViewHub  = new UpdatableViewHub();
            
            _inputView.Init(_coreSystems.ClickInputSystem, _coreSystems.DragInputSystem);
            _selectionUpdaterView.Init(_coreSystems.SelectionSystem, _coreSystems.ClickInputSystem, _raycasterService);
            _cameraMoverView.Init(_coreSystems.DragInputSystem);
            
            _updatableViewHub.RegisterView(_inputView);
            _updatableViewHub.RegisterView(_selectionUpdaterView);
            _updatableViewHub.RegisterView(_cameraMoverView);
        }

        void Update()
        {
            _updatableViewHub.UpdateViews();
            _coreSystems.UpdateCore();
        }
    }
}