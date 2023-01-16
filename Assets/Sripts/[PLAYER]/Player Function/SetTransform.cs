using UnityEngine;
using Player.Function;

namespace Player.Function {
    public class SetTransform : PlayerFunction {
        public override void RunFunction(Vector3 position, Quaternion rotatioin) {
            PlayerControl.transform.position = position;
            PlayerControl.transform.rotation = rotatioin;
        }
    }
}
