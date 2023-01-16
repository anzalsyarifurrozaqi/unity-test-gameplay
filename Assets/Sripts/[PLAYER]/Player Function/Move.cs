using UnityEngine;
using Manager;
using Enum;

namespace Player.Function {
    public class Move : PlayerFunction {
        public override void RunFunction(Vector2 input) {
            PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], input.y);
            PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Vertical], input.x);
        }
    }
}
