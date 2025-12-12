using Source.Scripts.Core.CoreData;

namespace Source.Scripts.Core
{
    public class CoreWorld
    {
        private ClickInputData _clickInputData = new();
        private DragInputData _dragInputData = new();
        private SelectionData _selectionData = new();

        internal ref ClickInputData GetClickInputData() => ref _clickInputData;
        internal ref DragInputData GetDragInputData() => ref _dragInputData;
        internal ref SelectionData GetSelectionData() => ref _selectionData;
    }
}