using UnityEngine;

namespace Zombie.Update {
    public class ZombieUpdate : MonoBehaviour {
        public ZombieControl ZombieControl;
        public virtual void InitComponent(){}
        public virtual void OnLateUpdate(){}
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}
    }
}
