using UnityEngine;

namespace Player.Update
{
    public class PlayerUpdate : MonoBehaviour
    {
        public PlayerControl PlayerControl;

        public virtual void InitComponent(){}
        public virtual void OnLateUpdate(){}
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}
    }
}