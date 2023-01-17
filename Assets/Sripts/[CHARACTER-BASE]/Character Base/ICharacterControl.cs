using UnityEngine;
using Character.Base.Dataset;

namespace Character.Base {
    public interface ICharacterControl {
        public Transform transform {get;}
        public BoxCollider BOX_COLLIDER {get;}
        public IDataset DATASET {get;}
        public virtual void RunGlobalFunction(System.Type type) {}
        public virtual void RunGlobalFunction(System.Type type, float value1) {}
    }
}
