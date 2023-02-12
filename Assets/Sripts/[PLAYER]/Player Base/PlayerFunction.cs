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

        public virtual void RunFunction(Vector2 value, ref Quaternion outValue) {
            throw new System.NotImplementedException();
        }

        public virtual void RunFunction(Transform targetShoot, bool isAnalogTriggered, ref Quaternion targetRotation) {
            throw new System.NotImplementedException();
        }
    }
}