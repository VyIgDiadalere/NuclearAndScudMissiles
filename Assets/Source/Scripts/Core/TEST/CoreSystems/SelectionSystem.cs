namespace Source.Scripts.Core.TEST
{
    public class SelectionSystem : ICoreSystem
    {
        private readonly CoreWorld _coreWorld;

        public SelectionSystem(CoreWorld coreWorld)
        {
            _coreWorld = coreWorld;
        }

        public void Update()
        {
            ref var inputData = ref _coreWorld.InputData;
            ref var selectionData = ref _coreWorld.SelectionData;
            
            if(inputData.Click == false)
            {
                return;
            }

            int hitId = _coreWorld.RaycastService.TryGetSelectableObject(inputData.XPosition, inputData.YPosition);

            if (hitId != selectionData.SelectedId)
            {
                selectionData.SelectedId = hitId;
                selectionData.Changed = true;
            }
            
            inputData.Click = false;
        }
    }
}