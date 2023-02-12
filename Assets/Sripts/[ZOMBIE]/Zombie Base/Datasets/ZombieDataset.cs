using UnityEngine;
using Character.Base.Dataset;

namespace Zombie.Dataset {
    public class ZombieDataset : MonoBehaviour, IDataset {
        public AbilityData _ABILITY_DATA;
        public AbilityData ABILITY_DATA => _ABILITY_DATA;
        public CollisionSpheresData _COLLISION_SPHERES_DATA;

        public CollisionSpheresData COLLISION_SPHERES_DATA => _COLLISION_SPHERES_DATA;
        public BlockingData _BLOCKING_DATA;

        public BlockingData BLOCKING_DATA => _BLOCKING_DATA;
    }
}
