using Source.Scripts.Core;
using System.Numerics;

namespace Source.Scripts.GENERAL.InputService
{
    public interface IInputService
    {
        public IReadOnlyReactiveProperty<bool> IsTouching { get;  }
        public IReadOnlyReactiveProperty<Vector2> CurrentTouchPosition { get; }
        public IReadOnlyReactiveProperty<Vector2> MovementDelta { get; }
        public IReadOnlyReactiveProperty<Vector2> ReleasePoint { get; }
        
        public void Enable();
        public void Disable();
        public void Update();
    }
}