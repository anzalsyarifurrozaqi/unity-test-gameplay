using UnityEngine;
using Character.Base.Dataset;

namespace Dataset {
    public class PlayerDatasets : MonoBehaviour, IDataset{
        public AbilityData ABILITY_DATA;
        public CameraSwitchData CAMERA_SWITCH_DATA;
        public TargetData TARGET_DATA;        

        
        public CollisionSpheresData _COLLISION_SPHERES_DATA;
        public CollisionSpheresData COLLISION_SPHERES_DATA => _COLLISION_SPHERES_DATA;
        public BlockingData _BLOCKING_DATA;

        public BlockingData BLOCKING_DATA => _BLOCKING_DATA;
    }
}