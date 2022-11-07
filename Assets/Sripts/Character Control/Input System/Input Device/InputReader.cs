using UnityEngine;
using UnityEngine.InputSystem;

namespace Input.Device {
    public class InputReader : MonoBehaviour {

        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private bool _inputSystemInitialized = false;
        public Vector2 Move;
        public Vector2 Look;

        void OnDisable()
        {
            _resetInputSystem();
        }
        void Awake()
        {
            _inputSystem = new InputSystem();            
        }

        void Update()
        {
            if (!_inputSystemInitialized)
                _initInputSystem();

        }

        private void _initInputSystem()
        {
            _inputSystem.Enable();
            _inputSystem.Player.MOVE.performed += _onMove;
            _inputSystem.Player.LOOK.performed += _onLook;
        }

        private void _resetInputSystem()
        {
            _inputSystem.Disable();
            _inputSystem.Player.MOVE.performed -= _onMove;
            _inputSystem.Player.LOOK.performed -= _onLook;
        }

        private void _onMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }

        private void _onLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
        }
    }
}
