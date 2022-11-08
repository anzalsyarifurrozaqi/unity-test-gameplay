using UnityEngine;
using Manager;

namespace Character.Update {
    public class ManualInput : CharacterUpdate {
        GameObject cube;
        Plane plane = new Plane(Vector3.up, 0);
        Vector2 currentCursorPosition;
        bool analogTriggered = false;
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
            analogTriggered = false;

            if (CharacterControl.Move.magnitude != 0)
            {
                analogTriggered = true;
                inputWorldPosition = new Vector3(CharacterControl.Move.x, 0.0f, CharacterControl.Move.y);
                target = Vector3.up - inputWorldPosition;
                angle = Quaternion.LookRotation(target).eulerAngles;
                targetRotation = Quaternion.Slerp(CharacterControl.transform.rotation, Quaternion.Euler(0.0f, angle.y, 0.0f), Time.deltaTime * timeSpeed);                                
            }

            if ((CharacterControl.Look - currentCursorPosition).magnitude == 0 || analogTriggered)
            {
                return;
            }            
            
            currentCursorPosition = CharacterControl.Look;
            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.Look);
            if (plane.Raycast(ray, out distance))
            {
                cube.transform.position = ray.GetPoint(distance);
                target = cube.transform.position - CharacterControl.transform.position;
                angle = Quaternion.LookRotation(target).eulerAngles;                
                targetRotation = Quaternion.Euler(0.0f, angle.y, 0.0f);
            }
        }

        public override void OnFixedUpdate()
        {
            CharacterControl.RIGID_BODY.MoveRotation(targetRotation);
        }
    }
}