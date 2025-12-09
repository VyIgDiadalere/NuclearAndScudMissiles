using System.Numerics;
using Source.Scripts.GENERAL.Extensions;
using Source.Scripts.GENERAL.InputService;
using Source.Scripts.View.Interfaces;

namespace Source.Scripts.GENERAL.SelectionSystem
{
    public class SelectionServicePresenter
    {
        private readonly IInputService _inputService;
        private readonly IRaycasterService _mainRaycasterService;
        private readonly SelectionServiceModel  _selectionServiceModel;
        
        private SelectedObjectViewHandler  _selectedObjectViewHandler;
        
        public SelectionServicePresenter(RaycasterService mainRaycasterService, IInputService inputService, SelectedObjectViewHandler viewHandler)
        {
            _inputService = inputService;
            _mainRaycasterService = mainRaycasterService;
            _selectedObjectViewHandler = viewHandler;
            
            _inputService.ReleasePoint.Changed += TrySelectObject;
        }
        
        private void TrySelectObject(Vector2 touchPosition)
        {
            var selectableObject = _mainRaycasterService.TryGetSelectableObject(touchPosition);
            
            _selectionServiceModel.SetSelectedObject(selectableObject);
        }
    }
}