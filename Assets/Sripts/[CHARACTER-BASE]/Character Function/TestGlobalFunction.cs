using UnityEngine;

namespace Character.Base.Function {
    public class TestGlobalFunction : CharacterBaseFunction<ICharacterControl> {
        public override void RunGlobalFunction() {
            Debug.Log("Test Global function");
            Debug.Log(CharacterControl.transform.position);
        }
    }
}
