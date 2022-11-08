using UnityEngine;
using Manager;
using Character.Function;
using Enum;

namespace Character.Update {
    public class ManualInput : CharacterUpdate {
        GameObject cube;
        Plane plane = new Plane(Vector3.up, 0);
        Vector2 currentCursorPosition;
        bool analogTriggered = false;
        bool cursorTriggered = false;
        static float timeSpeed = 10.0f;
        Quaternion targetRotation = Quaternion.identity;
        public override void InitComponent()
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            cube.transform.rotation = Quaternion.identity;
            cube.GetComponent<Collider>().isTrigger = true;
        }
        public override void OnUpdate()
        {
            float distance;
            Vector3 inputWorldPosition;
            Vector3 target;
            Vector3 angle;            

            CharacterControl.Move = InputManager.Instance.Move;
            CharacterControl.Look = InputManager.Instance.Look;
            CharacterControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], 0);
            CharacterControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Vertical], 0);
            analogTriggered = false;
            cursorTriggered = false;

            var moveMagnitude = CharacterControl.Move.magnitude;
            var lookMagnitude = (CharacterControl.Look - currentCursorPosition).magnitude;        
            
            if (moveMagnitude != 0)
            {
                // move direction
                analogTriggered = true;                
            }

            if (lookMagnitude != 0)
            {
                // cursor direction
                currentCursorPosition = CharacterControl.Look;
                Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.Look);
                if (plane.Raycast(ray, out distance))
                {
                    cube.transform.position = ray.GetPoint(distance);
                    cursorTriggered = true;
                }                
            }

            if (analogTriggered)
            {                
                target = cube.transform.position - CharacterControl.transform.position;
                angle = Quaternion.LookRotation(target).eulerAngles;                
                targetRotation = Quaternion.Euler(0.0f, angle.y, 0.0f);

                CharacterControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], CharacterControl.Move.y);
                CharacterControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Vertical], CharacterControl.Move.x);
            }
            
            //TODO: DIPISAH
            // else if (analogTriggered)
            // {
            //     inputWorldPosition = new Vector3(CharacterControl.Move.x, 0.0f, CharacterControl.Move.y);
            //     target = Vector3.up - inputWorldPosition;
            //     angle = Quaternion.LookRotation(target).eulerAngles;
            //     targetRotation = Quaternion.Slerp(CharacterControl.transform.rotation, Quaternion.Euler(0.0f, angle.y, 0.0f), Time.deltaTime * timeSpeed);

            //     CharacterControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.Horizontal], 1);                
            // }
            // else if (cursorTriggered)
            // {
            //     target = cube.transform.position - CharacterControl.transform.position;
            //     angle = Quaternion.LookRotation(target).eulerAngles;                
            //     targetRotation = Quaternion.Euler(0.0f, angle.y, 0.0f);
            // }            
        }

        public override void OnFixedUpdate()
        {
            CharacterControl.RIGID_BODY.MoveRotation(targetRotation);
        }
    }
}