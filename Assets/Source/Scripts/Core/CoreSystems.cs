using System.Collections.Generic;
using Source.Scripts.Core.CoreInterfaces;
using Source.Scripts.Core.CoreSystem;

namespace Source.Scripts.Core
{
    public class CoreSystems
    {
        private readonly ClickInputSystem _clickInputSystem;
        private readonly DragInputSystem _dragInputSystem;
        private readonly SelectionSystem _selectionSystem;

        private List<IUpdatableSystem> _updatableSystems = new();

        public CoreSystems(CoreWorld world)
        {
            _clickInputSystem  = new ClickInputSystem(world);
            _dragInputSystem = new DragInputSystem(world);
            _selectionSystem = new SelectionSystem(world);
        }
        
        public IClickInputSystem ClickInputSystem => _clickInputSystem;
        public IDragInputSystem DragInputSystem => _dragInputSystem;
        public ISelectionSystem SelectionSystem => _selectionSystem;

        public void UpdateCore()
        {
            if (_updatableSystems.Count > 0)
            {
                foreach (var updatableSystem in _updatableSystems)
                {
                    updatableSystem.Update();
                }
            }
        }
    }
}