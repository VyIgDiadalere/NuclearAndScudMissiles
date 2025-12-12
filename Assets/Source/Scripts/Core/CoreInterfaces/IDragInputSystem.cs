using Source.Scripts.Core.CoreData;

namespace Source.Scripts.Core.CoreInterfaces
{
    public interface IDragInputSystem 
    {
        public DragInputData GetDragInputData();
        void SetDragData(float xValue, float yValue);
        void ResetDragData();
    }
}