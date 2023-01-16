using UnityEngine;
using Manager;
using Player.Function;
using Enum;

namespace Player.Update {
    public class ManualInput : PlayerUpdate {
        GameObject cube;
        Plane plane = new Plane(Vector3.up, 0);
        Vector2 currentCursorPosition;
        bool analogTriggered = false;        
        static float timeSpeed = 20.0f;
        Quaternion targetRotation = Quaternion.identity;        
        public override void InitComponent()
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            cube.transform.rotation = Quaternion.identity;
            cube.GetComponent<Collider>().enabled = false;

            // test global function
            PlayerControl.RunGlobalFunction(typeof(TestGlobalFunction));
        }
        public override void OnUpdate()
        {
            float distance;
            Vector3 inputWorldPosition;
            Vector3 target;
            Vector3 angle;            

            PlayerControl.Move = InputManager.Instance.Move;
            PlayerControl.Look = InputManager.Instance.Look;
            PlayerControl.IsShoot = InputManager.Instance.IsShoot;
                    
            PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], 0);
            PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Vertical], 0);
            analogTriggered = false;            

            var moveMagnitude = PlayerControl.Move.magnitude;
            var lookMagnitude = (PlayerControl.Look - currentCursorPosition).magnitude;        
            
            if (moveMagnitude != 0)
            {
                // move direction
                analogTriggered = true;                
            }

            currentCursorPosition = PlayerControl.Look;
            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.Look);
            if (plane.Raycast(ray, out distance))
            {
                cube.transform.position = ray.GetPoint(distance);                
            }

            if (PlayerControl.IsShoot) { // shoot mode
                if (analogTriggered) {                
                    target = cube.transform.position - PlayerControl.transform.position;
                    angle = Quaternion.LookRotation(target).eulerAngles;                
                    targetRotation = Quaternion.Euler(0.0f, angle.y, 0.0f);

                    PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], PlayerControl.Move.y);
                    PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Vertical], PlayerControl.Move.x);
                }
                else {
                    target = cube.transform.position - PlayerControl.transform.position;
                    angle = Quaternion.LookRotation(target).eulerAngles;                
                    targetRotation = Quaternion.Euler(0.0f, angle.y, 0.0f);
                }
                                
                PlayerControl.RunFunction(typeof(ShotDirection));
                return;
            }

            if (analogTriggered) {
                inputWorldPosition = new Vector3(PlayerControl.Move.x, 0.0f, PlayerControl.Move.y);
                target = Vector3.up - inputWorldPosition;
                angle = Quaternion.LookRotation(target).eulerAngles;
                targetRotation = Quaternion.Lerp(PlayerControl.transform.rotation, Quaternion.Euler(0.0f, angle.y, 0.0f), Time.deltaTime * timeSpeed);

                PlayerControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], 1);                
            }                                    
        }

        public override void OnFixedUpdate()
        {
            PlayerControl.RIGID_BODY.MoveRotation(targetRotation);
        }
    }
}