using UnityEngine;

namespace Character.Base.Dataset {
    public interface IDataset {
        public CollisionSpheresData COLLISION_SPHERES_DATA {get;}
        public BlockingData BLOCKING_DATA {get;}
    }
}
