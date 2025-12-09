using Source.Scripts.Core;
using UnityEngine;

namespace Source.Scripts.View
{
    public class NuclearMessile : MonoBehaviour, ISelectableObject
    {
        public ReactiveProperty<bool> IsSelected { get; } = new();
        public void Select()
        {
            IsSelected.Value = true;
        }

        public void RemoveSelection()
        {
            IsSelected.Value = false;
        }
    }
}