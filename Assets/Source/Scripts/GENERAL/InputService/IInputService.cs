using UniRx;
using UnityEngine;

namespace Source.Scripts.GENERAL.InputService
{
    public interface IInputService
    {
        public ReactiveProperty<bool> IsTouching { get;  }
        public ReactiveProperty<Vector2> CurrentTouchPosition { get; }
        public ReactiveProperty<Vector2> MovementDelta { get; }
        public ReactiveProperty<Vector2> ReleasePoint { get; }
        
        public void Enable();
        public void Disable();
        public void Update();
    }
}