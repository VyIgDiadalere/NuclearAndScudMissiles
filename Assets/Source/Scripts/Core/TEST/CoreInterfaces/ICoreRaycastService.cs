using System.Numerics;

namespace Source.Scripts.Core.TEST
{
    public interface ICoreRaycastService
    {
        int TryGetSelectableObject(float x, float y);
        public Vector3? TryGetTerrainPoint(float x, float y);
    }
}