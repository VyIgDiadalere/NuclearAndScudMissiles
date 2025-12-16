using System;
using Source.Scripts.Core.CoreInterfaces;
using Source.Scripts.View.TEST;
using UnityEngine;

namespace Source.Scripts.View.Systems.SelectionSystem
{
    public class SelectionUpdaterView : MonoBehaviour, IUpdatableView
    {
        private ISelectionSystem _selectionSystem;
        private IClickInputSystem _clickInputSystem;
        private ICoreRaycastService _raycastService;

        private bool _isInitialize = false;

        public void Init(ISelectionSystem selectionSystem, IClickInputSystem clickInputSystem, ICoreRaycastService raycastService)
        {
            _selectionSystem = selectionSystem;
            _clickInputSystem  = clickInputSystem;
            _raycastService = raycastService;
            _isInitialize = true;
        }
        
        public void Refresh()
        {
            if (_isInitialize == false)
            {
                return;
            }
            
            var inputData = _clickInputSystem.GetClickInputData();

            if (_clickInputSystem.GetClickInputData().Click == false)
            {
                return;
            }
            
            int hitId = _raycastService.TryGetSelectableObjectId(inputData.XPosition, inputData.YPosition);
            
            _selectionSystem.SetSelectionData(hitId);
            var selection = _selectionSystem.GetSelectionData();         /////// УДАЛИТЬ ОТСЮДА, НЕ ЕГО ЛОГИКА ( НА ДАННЫЙ МОМЕНТ ТЕСТ РАБОТЫ)

            if (selection.Changed)
            {
                Debug.Log("Selected object ID: " + selection.SelectedId);

                _selectionSystem.ResetSelectionChangedStatus();
            }
        }
    }
}