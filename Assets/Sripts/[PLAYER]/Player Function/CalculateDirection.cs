using UnityEngine;

namespace Player.Function {    
    public class CalculateDirection : PlayerFunction {
        const float _turnSpeed = 2.5f;
        public override void RunFunction(Vector2 input) {            
            var angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.Euler(0, angle, 0);

            PlayerControl.transform.rotation = Quaternion.Slerp(PlayerControl.transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }
    }
}