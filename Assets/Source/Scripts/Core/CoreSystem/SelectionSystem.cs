using Source.Scripts.Core.CoreData;
using Source.Scripts.Core.CoreInterfaces;

namespace Source.Scripts.Core.CoreSystem
{
    public class SelectionSystem : ISelectionSystem
    {
        private readonly DataHolder _dataHolder;

        public SelectionSystem(DataHolder dataHolder)
        {
            _dataHolder = dataHolder;
        }
        
        public SelectionData GetSelectionData()
        {
            return _dataHolder.GetSelectionData();
        }

        public void ResetSelectionChangedStatus()
        {
            _dataHolder.GetSelectionData().Changed = false;
        }

        public void SetSelectionData(int hitId)
        {
            ref var inputData = ref _dataHolder.GetClickInputData();
            ref var selectionData = ref _dataHolder.GetSelectionData();
            
            if (hitId != selectionData.SelectedId)
            {
                selectionData.SelectedId = hitId;
                selectionData.Changed = true;
            }
            
            inputData.Click = false;
        }
    }
}