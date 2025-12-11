namespace Source.Scripts.Core.TEST
{
    public interface IClickInput
    {
        void SetClickData(bool click, float xPosition, float yPosition);
        void ResetClickData();
    }
}