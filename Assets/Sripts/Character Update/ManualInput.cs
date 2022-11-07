using UnityEngine;
using Manager;

namespace Character.Update {
    public class ManualInput : CharacterUpdate {
        GameObject cube;
        Plane plane = new Plane(Vector3.up, 0);
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
            CharacterControl.Move = InputManager.Instance.Move;
            CharacterControl.Look = InputManager.Instance.Look;

            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.Look);
            if (plane.Raycast(ray, out distance))
            {
                cube.transform.position = ray.GetPoint(distance);
                var target = cube.transform.position - CharacterControl.transform.position;
                var angle = Quaternion.LookRotation(target).eulerAngles;
                CharacterControl.transform.rotation = Quaternion.Slerp(CharacterControl.transform.rotation, Quaternion.Euler(0.0f, angle.y, 0.0f), Time.time);
            }

        }
    }
}