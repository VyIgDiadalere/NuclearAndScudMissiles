using System.Collections.Generic;

namespace Source.Scripts.Core.TEST
{
    public class CoreWorld
    {
        public CameraMovementData CameraMovementData;
        public SelectionData SelectionData;
        
        private SelectionSystem _selectionSystem;
        
        public ISele
        
        private List<ICoreSystem> _systems;
        
        public ICoreRaycastService RaycastService;

        public CoreWorld(ICoreRaycastService raycastService)
        {
            CameraMovementData = new CameraMovementData();
            SelectionData = new SelectionData();
            RaycastService = raycastService;
            
            
            _systems = new List<ICoreSystem>
            {
                new SelectionSystem(this),
                new InputSystem(this),
            };
        }
    }
}