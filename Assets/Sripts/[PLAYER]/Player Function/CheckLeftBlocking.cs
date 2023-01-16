using UnityEngine;
using Player.Function;

public class CheckLeftBlocking : PlayerFunction {
    public override void RunFunction(float rayDistance) {
        foreach (GameObject obj in PlayerControl.DATASET.COLLISION_SPHERES_DATA.LeftSpheres) {
            RaycastHit[] hits;
            Debug.DrawRay(obj.transform.position, -obj.transform.right * rayDistance, Color.green);
            hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, rayDistance);

            foreach (RaycastHit hit in hits) {
                AddObjectToDictionary.Add(
                    PlayerControl.DATASET.BLOCKING_DATA.LeftBlockingObjects,
                    obj,
                    hit.collider.gameObject
                );
            }
        }
    }
}
