using UniRx;

namespace Source.Scripts
{
    public interface ISelectableObject
    {
        public ReactiveProperty<bool> IsSelected { get; }
        
        public void Select();
        public void RemoveSelection();
    }
}