using UnityEngine;
using Player.Function;

public class CheckBackBlocking : PlayerFunction {
    public override void RunFunction(float rayDistance) {
        foreach (GameObject obj in PlayerControl.DATASET.COLLISION_SPHERES_DATA.BackSpheres) {
            RaycastHit[] hits;
            Debug.DrawRay(obj.transform.position, -obj.transform.forward * rayDistance, Color.green, rayDistance);
            hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, rayDistance);

            foreach (RaycastHit hit in hits) {
                AddObjectToDictionary.Add(
                    PlayerControl.DATASET.BLOCKING_DATA.BackBlockingObjects,
                    obj,
                    hit.collider.gameObject
                );
            }
        }
    }
}
