using UnityEngine;

namespace Zombie.Function {
    public class ZombieFunction : MonoBehaviour {
        public ZombieControl ZombieControl;
        public virtual void RunFunction() {
            throw new System.NotImplementedException();
        }
        public virtual void RunFunction(ZombieControl value1) {
            throw new System.NotImplementedException();
        }
    }
}
