using System;

namespace Source.Scripts.Core
{
    public interface IReadOnlyReactiveProperty <T> 
    {
        T Value { get; }
        
        event Action<T> Changed;
    }
}