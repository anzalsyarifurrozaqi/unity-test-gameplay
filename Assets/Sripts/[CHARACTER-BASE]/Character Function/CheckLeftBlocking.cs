using UnityEngine;
using Player.Function;

namespace Character.Base.Function {
    public class CheckLeftBlocking : CharacterBaseFunction<ICharacterControl> {
        public override void RunGlobalFunction(float rayDistance) {
            foreach (GameObject obj in CharacterControl.DATASET.COLLISION_SPHERES_DATA.LeftSpheres) {
                RaycastHit[] hits;
                Debug.DrawRay(obj.transform.position, -obj.transform.right * rayDistance, Color.green);
                hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, rayDistance);

                foreach (RaycastHit hit in hits) {
                    AddObjectToDictionary.Add(
                        CharacterControl.DATASET.BLOCKING_DATA.LeftBlockingObjects,
                        obj,
                        hit.collider.gameObject
                    );
                }
            }
        }
    }
}
