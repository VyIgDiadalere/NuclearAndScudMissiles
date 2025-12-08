using System;
using System.Numerics;
using Source.Scripts.GENERAL.InputService;
using Source.Scripts.View.Interfaces;

namespace Source.Scripts.Core
{
    public class CameraMoverPresenter : IDisposable
    {
        private readonly CameraMoverModel _model;
        private readonly ICameraMoverView _view;
        private readonly IInputService _inputService;
        

        public CameraMoverPresenter(ICameraMoverView view, IInputService inputService, CompositeDisposable  disposables)
        {
            _view = view;
            _inputService = inputService;
            disposables.Add(this);
            _model = new CameraMoverModel();
            _inputService.MovementDelta.Changed += SetMovement;
            _model.MovementDelta.Changed += SetView;
        }

        private void SetMovement(Vector2 movementDelta)
        {
            _model.SetMovementDelta(movementDelta);
        }

        private void SetView(Vector3 movementDelta)
        {
            _view.ApplyMove(movementDelta);
        }
        
        public void Dispose()
        {
            _inputService.MovementDelta.Changed -= SetMovement;
            _model.MovementDelta.Changed -= SetView;
        }
    }
}