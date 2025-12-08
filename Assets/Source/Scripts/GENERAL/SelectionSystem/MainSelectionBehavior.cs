using System.Numerics;
using Source.Scripts.Core;
using Source.Scripts.GENERAL.Extensions;
using Source.Scripts.GENERAL.InputService;
using Source.Scripts.View.Interfaces;

namespace Source.Scripts.GENERAL.SelectionSystem
{
    public class MainSelectionBehavior : IBaseBehavior
    {
        private readonly IInputService _inputService;
        private readonly Raycaster _mainRaycaster;
        private readonly SelectedObjectViewHandler _selectedObjectViewHandler;

        private CompositeDisposable _disposables = new CompositeDisposable();
        private CompositeDisposable _selectionDisposable = new CompositeDisposable();

        public ReactiveProperty<ISelectableObject> CurrentSelectableObject { get; private set; } = new();

        public MainSelectionBehavior(Raycaster mainRaycaster, IInputService inputService,
            SelectedObjectViewHandler viewHandler)
        {
            _mainRaycaster = mainRaycaster;
            _inputService = inputService;
            _selectedObjectViewHandler = viewHandler;
        }

        public void StartBehavior()
        {
            _disposables?.Dispose();
            _disposables = new CompositeDisposable();
            SubscribeToInputService(_disposables);
        }

        public void StopBehavior()
        {
            _disposables?.Dispose();
        }

        private void TrySelectObject(Vector2 touchPosition)
        {
            var selectableObject = _mainRaycaster.TryGetSelectableObject(touchPosition.ToUnityEngineVector2());
            
            if (selectableObject != null)
            {
                _selectionDisposable?.Dispose();
                _selectionDisposable = new CompositeDisposable();
                CurrentSelectableObject?.Value?.RemoveSelection();
                CurrentSelectableObject.Value = null;
                CurrentSelectableObject.Value = selectableObject;
                CurrentSelectableObject.Value.Select();

                ///**/CurrentSelectableObject?.Value?.IsSelected.Changed += ;
            }
        }

        private void SubscribeToInputService(CompositeDisposable disposable)
        {
            _inputService.ReleasePoint.Changed += TrySelectObject;
            
            /*_inputService.ReleasePoint
                .Subscribe(position =>
                {
                    var selectableObject = _mainRaycaster.TryGetSelectableObject(position);

                    if (selectableObject != null)
                    {
                        _selectionDisposable?.Dispose();
                        _selectionDisposable = new CompositeDisposable();
                        CurrentSelectableObject?.Value?.RemoveSelection();
                        CurrentSelectableObject.Value = null;
                        CurrentSelectableObject.Value = selectableObject;
                        CurrentSelectableObject.Value.Select();

                        CurrentSelectableObject?.Value?.IsSelected
                            .Where(isSelected => isSelected == false)
                            .Subscribe(_ =>
                            {
                                CurrentSelectableObject?.Value?.RemoveSelection();
                                CurrentSelectableObject.Value = null;
                                _selectionDisposable.Dispose();
                            }).AddTo(_selectionDisposable);
                    }
                    else
                    {
                        
                    }
                }).AddTo(disposable);

            CurrentSelectableObject.DistinctUntilChanged()
                .Subscribe(_selectedObjectViewHandler.RefreshView)
                .AddTo(disposable);*/
        }
    }
}