using System.Collections.Generic;
using Source.Scripts.View.Configs;
using Source.Scripts.View.TEST;

namespace Source.Scripts.View.Spawners
{
    public class BuildingSpawner
    {
        private Dictionary<int, SpawnableObjectPool<EntityView>> _buildingPartSpawners = new();

        public BuildingSpawner(ConfigRepository configRepository, SpawnableObjectFactory factory)
        {
            InitBuildingPartSpawners(configRepository.BuildingConfigs, factory);
        }

        private void InitBuildingPartSpawners(List<BuildingConfig> buildingConfigs, SpawnableObjectFactory factory)
        {
            foreach (var buildingConfig in buildingConfigs)
            {
                _buildingPartSpawners.Add(buildingConfig.ViewId, new SpawnableObjectPool<EntityView>(factory, buildingConfig.Prefab));
            }
        }
    }
}