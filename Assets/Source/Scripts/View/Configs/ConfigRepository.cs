using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.View.Configs
{
    public class ConfigRepository : MonoBehaviour
    {
        [SerializeField] private List<BuildingConfig> _buildingConfigs;

        public List<BuildingConfig> BuildingConfigs => _buildingConfigs;
    }
}