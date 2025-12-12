using Source.Scripts.Core.CoreData;

namespace Source.Scripts.Core.CoreInterfaces
{
    public interface ISelectionSystem
    {
        public void SetSelectionData(int hitId);
        public SelectionData GetSelectionData();
        public void ResetSelectionChangedStatus();
    }
}