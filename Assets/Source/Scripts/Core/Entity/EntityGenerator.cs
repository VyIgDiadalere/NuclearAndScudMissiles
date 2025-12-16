using System.Collections.Generic;

namespace Source.Scripts.Core.Entity
{
    public class EntityGenerator
    {
        private readonly Queue<int> _availableIds = new Queue<int>();
        private int _nextId = 1;

        public Entity GetEntity()
        {
            return new Entity(_availableIds.Count > 0 ? _availableIds.Dequeue() : _nextId++);
        }

        public void ReturnEntity(Entity entity)
        {
            _availableIds.Enqueue(entity.Id);
        }
    }
}