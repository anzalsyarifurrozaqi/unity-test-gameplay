using UnityEngine;
using Player.Function;

public class CheckFrontBlocking : PlayerFunction {
    public override void RunFunction(float rayDistance) {
        foreach (GameObject obj in PlayerControl.DATASET.COLLISION_SPHERES_DATA.FrontSpheres) {
            RaycastHit[] hits;
            Debug.DrawRay(obj.transform.position, obj.transform.forward * rayDistance, Color.green, rayDistance);
            hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, rayDistance);

            foreach (RaycastHit hit in hits) {
                AddObjectToDictionary.Add(
                    PlayerControl.DATASET.BLOCKING_DATA.FrontBlockingObjects,
                    obj,
                    hit.collider.gameObject
                );
            }
        }
    }
}
