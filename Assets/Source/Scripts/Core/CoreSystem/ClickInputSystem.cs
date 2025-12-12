using Source.Scripts.Core.CoreData;
using Source.Scripts.Core.CoreInterfaces;

namespace Source.Scripts.Core.CoreSystem
{
    public class ClickInputSystem: IClickInputSystem
    {
        private readonly CoreWorld _coreWorld;

        public ClickInputSystem(CoreWorld coreWorld)
        {
            _coreWorld = coreWorld;
        }

        public ClickInputData GetClickInputData()
        {
            return _coreWorld.GetClickInputData();
        }

        public void SetClickData(bool click, float xPosition, float yPosition)
        {
            _coreWorld.GetClickInputData().Click = true;
            _coreWorld.GetClickInputData().XPosition = xPosition;
            _coreWorld.GetClickInputData().YPosition = yPosition;
        }

        public void ResetClickData()
        {
            _coreWorld.GetClickInputData().Click = false;
        }
    }
}