using UnityEngine;

namespace Character.Base.Update {
    public class TestGlobalUpdate : CharacterBaseUpdate<ICharacterControl> {
        public override void InitComponent() {
            Debug.Log("test global update");
        }
        public override void OnUpdate() {
            // Debug.Log("test global update");
            // Debug.Log(CharacterControl.transform.position);
        }
    }    
}
