using UnityEngine;

namespace Character.Function {
    public class CharacterFunction : MonoBehaviour {
        public CharacterControl CharacterControl;

        public virtual void RunFunction() {
            throw new System.NotImplementedException();
        }   

        public virtual void RunFunction(CharacterControl control) {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Vector2 vector2) {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(float value) {
            throw new System.NotImplementedException();
        }
    }
}