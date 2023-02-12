using UnityEngine;
using Manager;
using Enum;

namespace Player.Function {
    public class PlayerShootMovement : PlayerFunction {
        public override void RunFunction(Transform targetShoot, bool isAnalogTriggered, ref Quaternion targetRotation) {            
            Vector3 target;
            Vector3 angle;

            target = targetShoot.position - PlayerControl.transform.position;
            angle = Quaternion.LookRotation(target).eulerAngles;                
            targetRotation = Quaternion.Euler(0.0f, angle.y, 0.0f);
            
            if (isAnalogTriggered) {                
                PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], PlayerControl.Move.y);
                PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Vertical], PlayerControl.Move.x);
            }
            
            PlayerControl.RunFunction(typeof(ShotDirection));
        }
    }

}
