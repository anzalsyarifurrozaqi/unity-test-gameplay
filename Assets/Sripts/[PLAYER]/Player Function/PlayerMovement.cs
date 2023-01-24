using UnityEngine;
using Manager;
using Enum;

namespace Player.Function {
    public class PlayerMovement : PlayerFunction {        
        private static float _timeSpeed = 20.0f;
        public override void RunFunction(Vector2 playerMove, ref Quaternion targetRotation) {
            Vector3 inputWorldPosition;
            Vector3 target;
            Vector3 angle;

            inputWorldPosition = new Vector3(PlayerControl.Move.x, 0.0f, PlayerControl.Move.y);
            target = Vector3.up - inputWorldPosition;
            angle = Quaternion.LookRotation(target).eulerAngles;
            targetRotation = Quaternion.Lerp(PlayerControl.transform.rotation, Quaternion.Euler(0.0f, angle.y, 0.0f), Time.deltaTime * _timeSpeed);

            PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], 1);
        }
    }
}
