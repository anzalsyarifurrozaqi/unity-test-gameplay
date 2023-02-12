using UnityEngine;

namespace Player.Function {
    public class MoveForward : PlayerFunction {
        const float _velocity = 2.5f;
        public override void RunFunction() {
            var transform = PlayerControl.transform;
            transform.position += transform.forward * _velocity * Time.deltaTime;
        }
    }
}
