using UnityEngine;

namespace Character.Base.Function {
    public class CheckBackBlocking : CharacterBaseFunction<ICharacterControl> {
        public override void RunGlobalFunction(float rayDistance) {
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
}
