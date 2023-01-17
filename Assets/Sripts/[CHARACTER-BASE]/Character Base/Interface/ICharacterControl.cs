using UnityEngine;
using Character.Base.Dataset;

namespace Character.Base {
    public interface ICharacterControl {
        public Transform transform {get;}
        public BoxCollider BOX_COLLIDER {get;}
        public IDataset DATASET {get;}
        public Rigidbody RIGID_BODY {get;}
        public Animator ANIMATOR {get;}
        public Vector2 MOVE {get;}
        public abstract void InitializeCharacter();
        public abstract void CharacterUpdate();
        public abstract void CharacterFixedUpdate();
        public abstract void CharacterLateUpdate();
        public virtual void RunGlobalFunction(System.Type type) {}
        public virtual void RunGlobalFunction(System.Type type, float value1) {}
    }
}
