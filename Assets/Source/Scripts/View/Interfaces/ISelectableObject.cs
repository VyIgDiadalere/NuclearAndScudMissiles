using Source.Scripts.Core;

namespace Source.Scripts.View.Interfaces
{
    public interface ISelectableObject
    {
        public ReactiveProperty<bool> IsSelected { get; }
        
        public void Select();
        public void RemoveSelection();
    }
}