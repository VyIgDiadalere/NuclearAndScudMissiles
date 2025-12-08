using Source.Scripts.GENERAL.Extensions.ViewExtensions;
using Source.Scripts.View.Interfaces;
using UnityEngine;

namespace Source.Scripts.GENERAL
{
    public class Raycaster: MonoBehaviour
    {
        [SerializeField] private LayerMask _terrainLayerMask;
        [SerializeField] private LayerMask _selectableOjbectLayerMask;
        [SerializeField] private LayerMask _uiLayerMask;
        
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        public ISelectableObject TryGetSelectableObject(Vector2 position)
        {
            var ray = _camera.ScreenPointToRay(position);
            
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

        public Vector3? TryGetTerrainPoint(Vector2 position)
        {
            var ray = _camera.ScreenPointToRay(position);
            
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _terrainLayerMask))
            {
                if (_uiLayerMask.IsContains(hit.collider.gameObject.layer))
                {
                    return null;
                }
                
                return hit.point;
            }

            return null;
        }
    }
}