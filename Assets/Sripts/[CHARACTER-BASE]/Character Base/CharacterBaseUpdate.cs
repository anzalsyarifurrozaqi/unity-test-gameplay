using UnityEngine;

namespace Character.Base {
    public class CharacterBaseUpdate<TCharacterControl> : MonoBehaviour where TCharacterControl : ICharacterControl {
        public TCharacterControl CharacterControl;
        public virtual void InitComponent(){}
        public virtual void OnUpdate() {}
        public virtual void OnFixedUpdate() {}
        public virtual void OnLateUpdate() {}
    }
}
