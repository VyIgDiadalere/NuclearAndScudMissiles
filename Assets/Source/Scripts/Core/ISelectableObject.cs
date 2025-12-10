namespace Source.Scripts.Core
{
    public interface ISelectableObject
    {
        //public ReactiveProperty<bool> IsSelected { get; }
        
        public void Select();
        public void RemoveSelection();
    }
}