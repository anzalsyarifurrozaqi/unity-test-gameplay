using UnityEngine;

namespace Character.Base {
    public class CharacterBaseFunction<TCharacterControl> : MonoBehaviour where TCharacterControl : ICharacterControl {    
        public TCharacterControl CharacterControl { get; set; }

        public virtual void RunGlobalFunction() {
            throw new System.NotImplementedException();
        }

        public virtual void RunGlobalFunction(float value1) {
            throw new System.NotImplementedException();
        }
    }
}
