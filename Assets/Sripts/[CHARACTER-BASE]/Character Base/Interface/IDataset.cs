using UnityEngine;
using Dataset;

namespace Character.Base.Dataset {
    public interface IDataset {
        public AbilityData ABILITY_DATA {get;}
        public CollisionSpheresData COLLISION_SPHERES_DATA {get;}
        public BlockingData BLOCKING_DATA {get;}
    }
}
