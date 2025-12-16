using Source.Scripts.View.TEST;
using UnityEngine;

namespace Source.Scripts.View.Configs
{
    [CreateAssetMenu(fileName = "BuildingConfig", menuName = "NewBuildingConfig", order = 0)]
    public class BuildingConfig : ScriptableObject
    {
        [SerializeField] private EntityView _prefab;
        [SerializeField] private int _viewId;
        
        public EntityView Prefab => _prefab;
        public int ViewId => _viewId;
    }
}