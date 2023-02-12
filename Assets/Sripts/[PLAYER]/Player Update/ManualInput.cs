using UnityEngine;
using Manager;
using Player.Function;
using Enum;
using Character.Base.Function;

namespace Player.Update {
    public class ManualInput : PlayerUpdate {
        GameObject cube;
        Plane plane = new Plane(Vector3.up, 0);
        Vector2 currentCursorPosition;
        bool isAnalogTriggered = false;        
        Quaternion targetRotation = Quaternion.identity;
        public override void InitComponent() {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            cube.transform.rotation = Quaternion.identity;
            cube.GetComponent<Collider>().enabled = false;

            // test global function
            PlayerControl.RunGlobalFunction(typeof(TestGlobalFunction));
        }
        public override void OnUpdate() {
            float distance;            

            PlayerControl.Move = InputManager.Instance.Move;
            PlayerControl.Look = InputManager.Instance.Look;
            PlayerControl.IsShoot = InputManager.Instance.IsShoot;
                    
            PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], 0);
            PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Vertical], 0);
            isAnalogTriggered = false;            

            var moveMagnitude = PlayerControl.Move.magnitude;
            var lookMagnitude = (PlayerControl.Look - currentCursorPosition).magnitude;        
            
            if (moveMagnitude != 0) {                
                isAnalogTriggered = true;                
            }

            currentCursorPosition = PlayerControl.Look;
            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.Look);
            if (plane.Raycast(ray, out distance)) {
                cube.transform.position = ray.GetPoint(distance);                
            }

            if (PlayerControl.IsShoot) { // shoot mode                
                PlayerControl.RunFunction(typeof(PlayerShootMovement), cube.transform, isAnalogTriggered, ref targetRotation);
                return;
            }

            if (isAnalogTriggered) {                
                PlayerControl.RunFunction(typeof(PlayerMovement), PlayerControl.Move, ref targetRotation);
            }                                    
        }

        public override void OnFixedUpdate() {
            PlayerControl.RIGID_BODY.MoveRotation(targetRotation);
        }
    }
}