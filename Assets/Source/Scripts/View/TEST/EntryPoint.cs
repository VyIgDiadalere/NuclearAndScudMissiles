using System;
using System.Collections.Generic;
using Source.Scripts.Core.TEST;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    [Serializable]
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private InputView _inputView;
        [SerializeField] private SelectionViewUpdater _selectionViewUpdater;
        [SerializeField] private ViewRaycasterService _raycasterService;
        [SerializeField] private CameraMoverView _cameraMoverView;
        
        private CoreWorld _world;
        private List<ICoreSystem> _systems;

        void Awake()
        {
            _world = new CoreWorld(_raycasterService);
            
            _inputView.Init(_world);
            _selectionViewUpdater.Init(_world);
            _cameraMoverView.Init(_world);
        }

        void Update()
        {
            foreach (var system in _systems)
                system.Update();
        }
    }
}