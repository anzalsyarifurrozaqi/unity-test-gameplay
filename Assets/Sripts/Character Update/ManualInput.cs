using UnityEngine;
using Manager;

namespace Character.Update {
    public class ManualInput : CharacterUpdate {
        public override void OnUpdate()
        {
            CharacterControl.Move = InputManager.Instance.Move;            
            CharacterControl.Attack = InputManager.Instance.Attack;
            CharacterControl.Dash = InputManager.Instance.Dash;
        }
    }
}