using Source.Scripts.Core.CoreData;
using Source.Scripts.Core.CoreInterfaces;

namespace Source.Scripts.Core.CoreSystem
{
    public class ClickInputSystem: IClickInputSystem
    {
        private readonly DataHolder _dataHolder;

        public ClickInputSystem(DataHolder dataHolder)
        {
            _dataHolder = dataHolder;
        }

        public ClickInputData GetClickInputData()
        {
            return _dataHolder.GetClickInputData();
        }

        public void SetClickData(bool click, float xPosition, float yPosition)
        {
            _dataHolder.GetClickInputData().Click = true;
            _dataHolder.GetClickInputData().XPosition = xPosition;
            _dataHolder.GetClickInputData().YPosition = yPosition;
        }

        public void ResetClickData()
        {
            _dataHolder.GetClickInputData().Click = false;
        }
    }
}