using UnityEngine;
using Character.Function;

public class CheckBackBlocking : CharacterFunction {
    public override void RunFunction(float rayDistance) {
        foreach (GameObject obj in CharacterControl.DATASET.COLLISION_SPHERES_DATA.BackSpheres) {
            RaycastHit[] hits;
            Debug.DrawRay(obj.transform.position, -obj.transform.forward * rayDistance, Color.green, rayDistance);
            hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, rayDistance);

            foreach (RaycastHit hit in hits) {
                AddObjectToDictionary.Add(
                    CharacterControl.DATASET.BLOCKING_DATA.BackBlockingObjects,
                    obj,
                    hit.collider.gameObject
                );
            }
        }
    }
}
