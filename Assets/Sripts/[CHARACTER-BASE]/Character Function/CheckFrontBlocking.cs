using UnityEngine;
using Player.Function;
using Character.Base;

namespace Character.Base.Function {
    public class CheckFrontBlocking : CharacterBaseFunction<ICharacterControl> {
        public override void RunGlobalFunction(float rayDistance) {
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
}
