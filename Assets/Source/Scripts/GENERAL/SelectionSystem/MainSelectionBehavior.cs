using Source.Scripts.Core;
using Source.Scripts.GENERAL.InputService;
using Vector2 = System.Numerics.Vector2;

namespace Source.Scripts.GENERAL.SelectionSystem
{
    public class MainSelectionBehavior : IBaseBehavior
    {
        private readonly IInputService _inputService;
        private readonly RaycasterService _mainRaycasterService;
        private readonly SelectedObjectViewHandler _selectedObjectViewHandler;
        
        private ISelectableObject _currentSelectableObject;

        public MainSelectionBehavior(RaycasterService mainRaycasterService, IInputService inputService, SelectedObjectViewHandler viewHandler)
        {
            _mainRaycasterService = mainRaycasterService;
            _inputService = inputService;
            _selectedObjectViewHandler = viewHandler;
        }

        public void StartBehavior()
        {
            _inputService.ReleasePoint.Changed += TrySelectObject;
        }

        public void StopBehavior()
        {
            if (_currentSelectableObject != null)
            {
                _currentSelectableObject.IsSelected.Changed -= ClearSelection;
            }
            
            _selectedObjectViewHandler.RefreshView(null);
            _inputService.ReleasePoint.Changed -= TrySelectObject;
        }

        private void TrySelectObject(Vector2 touchPosition)
        {
            var selectableObject = _mainRaycasterService.TryGetSelectableObject(touchPosition);
            
            if (selectableObject != null)
            {
                _currentSelectableObject?.RemoveSelection();
                _currentSelectableObject = selectableObject;
                _currentSelectableObject.Select();
                _selectedObjectViewHandler.RefreshView(selectableObject);
                
                _currentSelectableObject.IsSelected.Changed += ClearSelection;
            }
        }

        private void ClearSelection(bool isSelected)
        {
            if (isSelected == false)
            {
                _currentSelectableObject.IsSelected.Changed -= ClearSelection;
                _currentSelectableObject?.RemoveSelection();
                _selectedObjectViewHandler.RefreshView(_currentSelectableObject);
                _currentSelectableObject = null;
            }
        }
    }
}