using System.Numerics;
using Source.Scripts.Core;

namespace Source.Scripts.View.Interfaces
{
    public interface IRaycasterService
    {
        ISelectableObject TryGetSelectableObject(Vector2 screenPosition);
        Vector3? TryGetTerrainPoint(Vector2 screenPosition);
    }
}