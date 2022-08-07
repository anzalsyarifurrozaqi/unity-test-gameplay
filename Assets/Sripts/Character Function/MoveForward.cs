using UnityEngine;

namespace Character.Function {
    public class MoveForward : CharacterFunction {
        const float _velocity = 2.5f;
        public override void RunFunction() {
            var transform = CharacterControl.transform;
            transform.position += transform.forward * _velocity * Time.deltaTime;
        }
    }
}
