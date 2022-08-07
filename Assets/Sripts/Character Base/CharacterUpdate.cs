using UnityEngine;

namespace Character.Update
{
    public class CharacterUpdate : MonoBehaviour
    {
        public CharacterControl CharacterControl;

        public virtual void InitComponent(){}
        public virtual void OnLateUpdate(){}
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}
    }
}