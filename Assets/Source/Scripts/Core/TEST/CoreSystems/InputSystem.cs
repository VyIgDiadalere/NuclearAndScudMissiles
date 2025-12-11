namespace Source.Scripts.Core.TEST
{
    public class InputSystem: ICoreSystem, IClickInput, IDragInput
    {
        private readonly CoreWorld _coreWorld;
        private InputData _inputData;

        public InputSystem(CoreWorld coreWorld)
        {
            _inputData = new InputData();
            _coreWorld = coreWorld;
        }

        public InputData InputData => _inputData;
        
        public void Update()
        {
            var movement = _coreWorld.CameraMovementData;

            if (_inputData.IsDragging)
            {
                movement.MoveOffsetX = -_inputData.DragX;
                movement.MoveOffsetY = -_inputData.DragY;
            }
            else
            {
                movement.MoveOffsetX = 0;
                movement.MoveOffsetY = 0;
            }
            
            _coreWorld.CameraMovementData = movement;
        }

        public void SetClickData(bool click, float xPosition, float yPosition)
        {
            _inputData.Click = true;
            _inputData.XPosition = xPosition;
            _inputData.YPosition = yPosition;
        }

        public void ResetClickData()
        {
            _inputData.Click = false;
        }

        public void SetDragData(float xValue, float yValue)
        {
            _inputData.IsDragging = true;
            _inputData.DragX = xValue;
            _inputData.DragY = yValue;
        }

        public void ResetDragData()
        {
            _inputData.IsDragging = false;
            _inputData.DragX = 0;
            _inputData.DragY = 0;
        }
    }
}