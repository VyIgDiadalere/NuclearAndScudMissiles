using System.Numerics;

namespace Source.Scripts.Core.CoreInterfaces
{
    public interface ICoreRaycastService
    {
        int TryGetSelectableObjectId(float x, float y);
        public Vector3? TryGetTerrainPoint(float x, float y);
    }
}