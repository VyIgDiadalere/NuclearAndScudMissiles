using System;
using Source.Scripts.Core.Entity;
using Source.Scripts.View.Interfaces;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    public class EntityView : MonoBehaviour, ISpawnableObject<EntityView>
    {
        private Entity _entity;

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }
        
        public Entity GetEntity() => _entity;
        
        public event Action<EntityView> Disabled;
        
        public void Disable()
        {
            Disabled?.Invoke(this);
        }
    }
}