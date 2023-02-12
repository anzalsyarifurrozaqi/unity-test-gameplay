using UnityEngine;
using Character.Base.Function;

namespace Character.Base.Update {
    
    public class CollisionSphere : CharacterBaseUpdate<ICharacterControl> {
        GameObject Front = null;
        GameObject Back = null;
        GameObject Right = null;
        GameObject Left = null;
        GameObject Bottom = null;
        public override void InitComponent() {
            if (Bottom == null) {
                SetParent();
            }

            SetCollisionSpheres();
        }

        private void SetCollisionSpheres() {            
            CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;        

            // Front
            for (int i = 0; i < 3; ++i) {
                GameObject collisionSphere = LoadCollisionSpheresObject();

                collisionSpheresData.FrontSpheres[i] = collisionSphere;
                collisionSphere.transform.parent = Front.transform;
            }

            CharacterControl.RunGlobalFunction(typeof(Reposition_Spheres_Front));

            // Back
            for (int i = 0; i < 3; ++i) {
                GameObject collisionSphere = LoadCollisionSpheresObject();

                collisionSpheresData.BackSpheres[i] = collisionSphere;
                collisionSphere.transform.parent = Back.transform;            
            }

            CharacterControl.RunGlobalFunction(typeof(Reposition_Spheres_Back));

            // Left
            for (int i = 0; i < 3; ++i) {
                GameObject collisionSphere = LoadCollisionSpheresObject();

                collisionSpheresData.LeftSpheres[i] = collisionSphere;
                collisionSphere.transform.parent = Left.transform;
            }

            CharacterControl.RunGlobalFunction(typeof(Reposition_Spheres_Left));

            // Right
            for (int i = 0; i < 3; ++i) {
                GameObject collisionSphere = LoadCollisionSpheresObject();

                collisionSpheresData.RightSpheres[i] = collisionSphere;
                collisionSphere.transform.parent = Right.transform;            
            }

            CharacterControl.RunGlobalFunction(typeof(Reposition_Spheres_Right));

            // Bottom
            for (int i = 0; i < 3; ++i) {
                GameObject collisionSphere = LoadCollisionSpheresObject();

                collisionSpheresData.BottomSpheres[i] = collisionSphere;
                collisionSphere.transform.parent = Bottom.transform;            
            }

            CharacterControl.RunGlobalFunction(typeof(Reposition_Spheres_Bottom));
        }

        private void SetParent() {
            CreateParentObject(ref Front, "Front");
            CreateParentObject(ref Back, "Back");
            CreateParentObject(ref Left, "Left");
            CreateParentObject(ref Right, "Right");
            CreateParentObject(ref Bottom, "Bottom");
        }

        private void CreateParentObject( ref GameObject obj, string objName) {
            obj = new GameObject();
            obj.name = objName;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }

        private GameObject LoadCollisionSpheresObject() {
            GameObject obj = Instantiate(Resources.Load("CollisionSphere", typeof(GameObject))) as GameObject;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            return obj;
        }    
    }
}
