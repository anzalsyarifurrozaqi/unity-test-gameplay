using UnityEngine;

namespace Manager {
    public class InputManager : Singleton<InputManager> {
        public Vector2 Move;
        public Vector2 Look;        
        public bool IsShoot;
        public void LoadPlayerInput() {
            var obj = Resources.Load<GameObject>("PlayerInput");
            GameObject p = Instantiate(obj) as GameObject;
        }
    }
}
