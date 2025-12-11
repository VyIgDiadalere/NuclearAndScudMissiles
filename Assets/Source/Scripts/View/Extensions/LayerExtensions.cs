using UnityEngine;

namespace Source.Scripts.View.Extensions
{
    public static class LayerExtensions
    {
        public static bool IsContains(this LayerMask thisLayer, LayerMask verifiableLayer)
        {
            return ((1 << verifiableLayer) & thisLayer.value) != 0;
        }
        
        public static bool IsContains(this LayerMask thisLayer, int layer)
        {
            return ((1 << layer) & thisLayer.value) != 0;
        }
        
        private static int GetFirstLayerFromMask(LayerMask layerMask)
        {
            int mask = layerMask.value;
            
            if (mask != 0 && (mask & (mask - 1)) == 0)
            {
                return (int)Mathf.Log(mask, 2);
            }
            
            for (int i = 0; i < 32; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    return i;
                }
            }
        
            return -1;
        }
    }
}