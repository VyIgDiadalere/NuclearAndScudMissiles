using Source.Scripts.Core.CoreData;

namespace Source.Scripts.Core.CoreInterfaces
{
    public interface IClickInputSystem 
    {
        public ClickInputData GetClickInputData();
        void SetClickData(bool click, float xPosition, float yPosition);
        void ResetClickData();
    }
}