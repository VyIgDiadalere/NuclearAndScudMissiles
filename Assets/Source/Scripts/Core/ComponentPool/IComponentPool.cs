namespace Source.Scripts.Core
{
    public interface IComponentPool
    {
        void AllocateComponent();
        bool HasComponent(int entity);
        void RemoveComponent(int entity);
    }
}