using UnityEngine;
using Character.Function;

namespace Character.Function {
    public class SetTransform : CharacterFunction {
        public override void RunFunction(Vector3 position, Quaternion rotatioin) {
            CharacterControl.transform.position = position;
            CharacterControl.transform.rotation = rotatioin;
        }
    }
}
