using UnityEngine;
using Character.Function;

public class CheckFrontBlocking : CharacterFunction {
    public override void RunFunction(float rayDistance) {
        foreach (GameObject obj in CharacterControl.DATASET.COLLISION_SPHERES_DATA.FrontSpheres) {
            RaycastHit[] hits;
            Debug.DrawRay(obj.transform.position, obj.transform.forward * rayDistance, Color.green, rayDistance);
            hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, rayDistance);

            foreach (RaycastHit hit in hits) {
                AddObjectToDictionary.Add(
                    CharacterControl.DATASET.BLOCKING_DATA.FrontBlockingObjects,
                    obj,
                    hit.collider.gameObject
                );
            }
        }
    }
}
