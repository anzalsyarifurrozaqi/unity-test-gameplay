using UnityEngine;
using Manager;
using Enum;

namespace Character.Function {
    public class Move : CharacterFunction {
        public override void RunFunction(Vector2 input) {
            CharacterControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], input.x);            
        }
    }
}
