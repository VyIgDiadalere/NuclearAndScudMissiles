using Source.Scripts.Core.CoreData;
using Source.Scripts.Core.CoreInterfaces;

namespace Source.Scripts.Core.CoreSystem
{
    public class DragInputSystem :  IDragInputSystem
    {
        private readonly CoreWorld _coreWorld;

        public DragInputSystem(CoreWorld coreWorld)
        {
            _coreWorld = coreWorld;
        }

        public DragInputData GetDragInputData()
        {
            return _coreWorld.GetDragInputData();
        }

        public void SetDragData(float xValue, float yValue)
        {
            _coreWorld.GetDragInputData().IsDragging = true;
            _coreWorld.GetDragInputData().DragX = -xValue;
            _coreWorld.GetDragInputData().DragY = -yValue;
        }

        public void ResetDragData()
        {
            _coreWorld.GetDragInputData().IsDragging = false;
            _coreWorld.GetDragInputData().DragX = 0;
            _coreWorld.GetDragInputData().DragY = 0;
        }
    }
}