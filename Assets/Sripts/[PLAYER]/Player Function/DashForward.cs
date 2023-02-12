using UnityEngine;

namespace Player.Function {
    public class DashForward : PlayerFunction {
        const float _velocity = 5.0f;
        public override void RunFunction() {
            var transform = PlayerControl.transform;
            transform.position += transform.forward * _velocity * Time.deltaTime;
        }
    }
}
