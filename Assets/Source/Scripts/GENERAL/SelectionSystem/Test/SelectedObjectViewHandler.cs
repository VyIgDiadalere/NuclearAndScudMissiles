using Source.Scripts.Core;
using Source.Scripts.View;

namespace Source.Scripts.GENERAL.SelectionSystem
{
    public class SelectedObjectViewHandler
    {
        private readonly MainViewPanel _mainViewPanel;
        
        public SelectedObjectViewHandler(MainViewPanel mainViewPanel)
        {
            _mainViewPanel = mainViewPanel;
        }

        public void RefreshView(ISelectableObject selectedObject)
        {
            if (selectedObject != null)
            {
                if (selectedObject.IsSelected.Value == true)
                {
                    _mainViewPanel.EnableNuclearMissileButton();
                }
                else
                {
                    _mainViewPanel.DisableNuclearMissileButton();
                }
            }
            else
            {
                _mainViewPanel.DisableNuclearMissileButton();
            }
        }
    }
}