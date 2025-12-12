using Source.Scripts.Core.CoreData;
using Source.Scripts.Core.CoreInterfaces;

namespace Source.Scripts.Core.CoreSystem
{
    public class SelectionSystem : ISelectionSystem
    {
        private readonly CoreWorld _coreWorld;

        public SelectionSystem(CoreWorld coreWorld)
        {
            _coreWorld = coreWorld;
        }
        
        public SelectionData GetSelectionData()
        {
            return _coreWorld.GetSelectionData();
        }

        public void ResetSelectionChangedStatus()
        {
            _coreWorld.GetSelectionData().Changed = false;
        }

        public void SetSelectionData(int hitId)
        {
            
            
            ref var inputData = ref _coreWorld.GetClickInputData();
            ref var selectionData = ref _coreWorld.GetSelectionData();
            
            if (hitId != selectionData.SelectedId)
            {
                selectionData.SelectedId = hitId;
                selectionData.Changed = true;
            }
            
            inputData.Click = false;
        }
    }
}