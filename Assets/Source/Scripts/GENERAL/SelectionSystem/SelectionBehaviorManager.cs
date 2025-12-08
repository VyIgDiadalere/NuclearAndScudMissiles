using Source.Scripts.Core;
using Source.Scripts.GENERAL.InputService;

namespace Source.Scripts.GENERAL.SelectionSystem
{
    public class SelectionBehaviorManager
    {
        private readonly MainSelectionBehavior _mainSelectionBehavior;
        private IBaseBehavior _baseBehavior;
        
        public SelectionBehaviorManager(Raycaster mainRaycaster, IInputService inputService, SelectedObjectViewHandler selectedObjectViewHandler, CompositeDisposable disposables)
        {
            _mainSelectionBehavior = new MainSelectionBehavior(mainRaycaster, inputService, selectedObjectViewHandler);
            
            SetBehavior(_mainSelectionBehavior);
        }
        
        private void SetBehavior<T>(T behavior) where T : IBaseBehavior
        {
            var type = typeof(T);

            if (_baseBehavior?.GetType() == type)
            {
                return;
            }

            _baseBehavior?.StopBehavior();
            _baseBehavior = behavior;
            _baseBehavior.StartBehavior();
        }
    }
}