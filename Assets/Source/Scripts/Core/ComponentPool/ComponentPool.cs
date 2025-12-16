using System;

namespace Source.Scripts.Core.ComponentPool
{
    public class ComponentPool <T> : IComponentPool where T: struct
    {
        private struct Component
        {
            public bool Exists;
            public T Value;
        }
        private Component[] _components =  new Component[8];

        public ref T GetComponent(int entity)
        {
            ref var component = ref this._components[entity];
            return ref component.Value;
        }
        
        public void SetComponent(int entity, ref T data)
        {
            while (entity >= this._components.Length)
            {
                AllocateComponent();
            }

            ref var component = ref this._components[entity];
            component.Exists = true;
            component.Value = data;
        }
        
        public void AllocateComponent()
        {
            Array.Resize(ref this._components, this._components.Length * 2);
        }

        public bool HasComponent(int entity)
        {
            if (entity >= this._components.Length)
            {
                return false;
            }
            
            return this._components[entity].Exists;
        }

        public void RemoveComponent(int entity)
        {
            if (entity >= this._components.Length)
                return;

            ref var component = ref this._components[entity];
            component.Exists = false;
        }
    }
}