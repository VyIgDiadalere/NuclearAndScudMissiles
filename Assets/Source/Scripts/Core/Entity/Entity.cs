namespace Source.Scripts.Core.Entity
{
    public struct Entity
    {
        private readonly int _Id;
        
        public Entity(int id)
        {
            _Id = id;
        }
        
        public int Id => _Id;
    }
}