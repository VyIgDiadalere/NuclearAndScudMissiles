using Source.Scripts.Core;

namespace Source.Scripts.GENERAL.SelectionSystem
{
    public class SelectionServiceModel
    {
        private ISelectableObject _currentSelectableObject;
        
        public void SetSelectedObject(ISelectableObject selectableObject)
        {
            _currentSelectableObject = selectableObject;
        }
    }
}