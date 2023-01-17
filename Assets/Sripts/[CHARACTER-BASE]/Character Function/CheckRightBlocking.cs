using UnityEngine;
using Player.Function;
using Character.Base;

namespace Character.Base.Function {
    public class CheckRightBlocking : CharacterBaseFunction<ICharacterControl> {
        public override void RunGlobalFunction(float rayDistance) {
            foreach (GameObject obj in CharacterControl.DATASET.COLLISION_SPHERES_DATA.RightSpheres) {
                RaycastHit[] hits;
                Debug.DrawRay(obj.transform.position, obj.transform.right * rayDistance, Color.green, rayDistance);
                hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, rayDistance);

                foreach (RaycastHit hit in hits) {
                    AddObjectToDictionary.Add(
                        CharacterControl.DATASET.BLOCKING_DATA.RightBlockingObjects,
                        obj,
                        hit.collider.gameObject
                    );
                }
            }
        }
    }
}
