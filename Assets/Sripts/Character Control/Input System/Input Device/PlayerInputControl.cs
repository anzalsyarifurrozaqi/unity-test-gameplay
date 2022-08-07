using UnityEngine;
using Manager;

namespace Input.Device {
    public class PlayerInputControl : MonoBehaviour {
        [SerializeField] private InputReader _inputReader;

        private void OnEnable() {
            _inputReader = GetComponent<InputReader>();
        }

        private void OnDisable() {
            _inputReader = null;
        }

        private void Update() {
            InputManager.Instance.Move = _inputReader.ReadMove();            
            InputManager.Instance.Attack = _inputReader.ReadAttack();
            InputManager.Instance.Dash = _inputReader.ReadDash();
        }
    }
}
