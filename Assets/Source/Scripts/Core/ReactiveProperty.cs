using System;
using System.Collections.Generic;

namespace Source.Scripts.Core
{
    public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>
    {
        private T _value;
        private IEqualityComparer<T> _comparer;

        public ReactiveProperty() : this(default(T))
        {
            
        }

        public ReactiveProperty(T value) : this(value, EqualityComparer<T>.Default)
        {
            
        }

        public ReactiveProperty(T value, IEqualityComparer<T> comparer)
        {
            _value = value;
            _comparer = comparer;
        }

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;
                _value = value;

                if (_comparer.Equals(oldValue, value) == false)
                {
                    Changed?.Invoke(_value);
                }
            }
        }

        public event Action<T> Changed;
    }
}