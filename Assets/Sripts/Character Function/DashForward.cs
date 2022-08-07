using UnityEngine;

namespace Character.Function {
    public class DashForward : CharacterFunction {
        const float _velocity = 5.0f;
        public override void RunFunction() {
            var transform = CharacterControl.transform;
            transform.position += transform.forward * _velocity * Time.deltaTime;
        }
    }
}
