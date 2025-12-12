using System;
using Source.Scripts.Core.CoreInterfaces;
using Source.Scripts.View.Extensions;
using Source.Scripts.View.Systems.SelectionSystem;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    [Serializable]
    public class ViewRaycasterService: MonoBehaviour, ICoreRaycastService
    {
        [SerializeField] private LayerMask _terrainLayerMask;
        [SerializeField] private LayerMask _selectableOjbectLayerMask;
        [SerializeField] private LayerMask _uiLayerMask;
        
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;    
        }
        
        public int TryGetSelectableObjectId(float x, float y)
        {
            var ray = _camera.ScreenPointToRay(new Vector3(x, y));

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _selectableOjbectLayerMask))
            {
                if (_uiLayerMask.IsContains(hit.collider.gameObject.layer))
                {
                    return -1;
                }
                
                if (hit.collider.TryGetComponent(out SelectableEntityView selectable))
                {
                    return selectable.Id;
                }
            }

            return -1;
        }

        public System.Numerics.Vector3? TryGetTerrainPoint(float x, float y)
        {
            var ray = _camera.ScreenPointToRay(new  Vector2(x, y));
            
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