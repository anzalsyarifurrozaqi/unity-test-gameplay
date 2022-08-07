using UnityEngine;

namespace Input.Device {
    public class InputReader : MonoBehaviour {

        private InputSystem _inputSystem;
        private void OnEnable() {
            _inputSystem.Enable();
        }

        private void OnDisable() {
            _inputSystem.Disable();
        }
        private void Awake() {
            _inputSystem = new InputSystem();
        }       


        public Vector2 ReadMove() {
            Vector2 moveValue = _inputSystem.Character.MOVE.ReadValue<Vector2>();

            if (moveValue.magnitude > 0f) {
                return moveValue;
            }

            return Vector2.zero;
        }

        public bool ReadAttack() {
            return _inputSystem.Character.ATTACK.inProgress;
        }

        public bool ReadDash() {
            return _inputSystem.Character.DASH.triggered;
        }
    }
}
