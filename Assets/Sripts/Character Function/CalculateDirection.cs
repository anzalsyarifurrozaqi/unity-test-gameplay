using UnityEngine;

namespace Character.Function {    
    public class CalculateDirection : CharacterFunction {
        const float _turnSpeed = 2.5f;
        public override void RunFunction(Vector2 input) {            
            var angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.Euler(0, angle, 0);

            CharacterControl.transform.rotation = Quaternion.Slerp(CharacterControl.transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }
    }
}