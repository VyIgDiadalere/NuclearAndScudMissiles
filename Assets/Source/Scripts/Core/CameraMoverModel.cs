using System.Numerics;

namespace Source.Scripts.Core
{
    public class CameraMoverModel
    {
        private readonly float _smoothSpeed = 0.1f;
        private readonly ReactiveProperty<Vector3> _movementDelta = new();
        
        public IReadOnlyReactiveProperty<Vector3> MovementDelta => _movementDelta;
        
        public void SetMovementDelta(System.Numerics.Vector2 delta)
        {
            if (delta == Vector2.Zero)
            {
                return;
            }
            
            _movementDelta.Value = new Vector3(-delta.X, 0, -delta.Y) * _smoothSpeed;
        }
    }
}