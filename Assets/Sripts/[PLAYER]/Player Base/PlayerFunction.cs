using UnityEngine;

namespace Player.Function {
    public class PlayerFunction : MonoBehaviour {        
        public PlayerControl PlayerControl;

        public virtual void RunFunction() {
            throw new System.NotImplementedException();
        }   

        public virtual void RunFunction(PlayerControl control) {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Vector2 vector2) {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(float value) {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Vector3 value, Quaternion value2) {
            throw new System.NotImplementedException();
        }
    }
}