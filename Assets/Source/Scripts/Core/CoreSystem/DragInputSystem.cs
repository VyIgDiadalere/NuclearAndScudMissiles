using Source.Scripts.Core.CoreData;
using Source.Scripts.Core.CoreInterfaces;

namespace Source.Scripts.Core.CoreSystem
{
    public class DragInputSystem :  IDragInputSystem
    {
        private readonly DataHolder _dataHolder;

        public DragInputSystem(DataHolder dataHolder)
        {
            _dataHolder = dataHolder;
        }

        public DragInputData GetDragInputData()
        {
            return _dataHolder.GetDragInputData();
        }

        public void SetDragData(float xValue, float yValue)
        {
            _dataHolder.GetDragInputData().IsDragging = true;
            _dataHolder.GetDragInputData().DragX = -xValue;
            _dataHolder.GetDragInputData().DragY = -yValue;
        }

        public void ResetDragData()
        {
            _dataHolder.GetDragInputData().IsDragging = false;
            _dataHolder.GetDragInputData().DragX = 0;
            _dataHolder.GetDragInputData().DragY = 0;
        }
    }
}