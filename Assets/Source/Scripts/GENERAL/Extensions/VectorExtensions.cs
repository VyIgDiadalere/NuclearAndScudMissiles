namespace Source.Scripts.GENERAL.Extensions
{
    public static class VectorExtensions
    {
        public static UnityEngine.Vector3 ToUnityEngineVector3(this System.Numerics.Vector3 vector)
        {
            return new UnityEngine.Vector3(vector.X, vector.Y, vector.Z);
        }

        public static System.Numerics.Vector3 ToNumericsVector3(this UnityEngine.Vector3 vector)
        {
            return new System.Numerics.Vector3(vector.x,vector.y,vector.z);
        }

        public static UnityEngine.Vector2 ToUnityEngineVector2(this System.Numerics.Vector2 vector)
        {
            return new UnityEngine.Vector2(vector.X, vector.Y);
        }

        public static System.Numerics.Vector2 ToNumericsVector2(this UnityEngine.Vector2 vector)
        {
            return new System.Numerics.Vector2(vector.x, vector.y);
        }
    }
}