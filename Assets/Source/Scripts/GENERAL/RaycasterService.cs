using Source.Scripts.GENERAL.Extensions;
using Source.Scripts.GENERAL.Extensions.ViewExtensions;
using Source.Scripts.View.Interfaces;
using UnityEngine;
using System.Numerics;
using Source.Scripts.Core;
using Vector3 = System.Numerics.Vector3;

namespace Source.Scripts.GENERAL
{
    public class RaycasterService: MonoBehaviour , IRaycasterService
    {
        [SerializeField] private LayerMask _terrainLayerMask;
        [SerializeField] private LayerMask _selectableOjbectLayerMask;
        [SerializeField] private LayerMask _uiLayerMask;
        
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        public ISelectableObject TryGetSelectableObject(System.Numerics.Vector2 screenPosition)
        {
            var ray = _camera.ScreenPointToRay(screenPosition.ToUnityEngineVector2());
            
            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _selectableOjbectLayerMask))
            {
                if (_uiLayerMask.IsContains(hit.collider.gameObject.layer))
                {
                    return null;
                }
                
                if (hit.collider.TryGetComponent(out ISelectableObject selectable))
                {
                    return selectable;
                }
            }

            return null;
        }

        public Vector3? TryGetTerrainPoint(System.Numerics.Vector2 screenPosition)
        {
            var ray = _camera.ScreenPointToRay(screenPosition.ToUnityEngineVector2());
            
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _terrainLayerMask))
            {
                if (_uiLayerMask.IsContains(hit.collider.gameObject.layer))
                {
                    return null;
                }
                
                return hit.point.ToNumericsVector3();
            }

            return null;
        }
    }
}