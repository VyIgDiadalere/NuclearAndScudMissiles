using Source.Scripts.Core.TEST;
using UnityEngine;

namespace Source.Scripts.View.TEST
{
    public class SelectionViewUpdater : MonoBehaviour
    {
        private CoreWorld _world;

        public void Init(CoreWorld world)
        {
            _world = world;
        }

        void Update()
        {
            ref var selection = ref _world.SelectionData;

            if (selection.Changed)
            {
                Debug.Log("Selected object ID: " + selection.SelectedId);

                selection.Changed = false;
            }
        }
    }
}