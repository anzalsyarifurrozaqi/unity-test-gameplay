using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Update;

public class CollisionSphere : CharacterUpdate {
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
        // Front
        for (int i = 0; i < 3; ++i) {
            GameObject collisionSphere = LoadCollisionSphresObject();

            CharacterControl.DATASET.COLLISION_SPHERES_DATA.FrontSpheres[i] = collisionSphere;
            collisionSphere.transform.parent = Front.transform;
        }

        CharacterControl.RunFunction(typeof(Reposition_Spheres_Front));
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

    private GameObject LoadCollisionSphresObject() {
        GameObject obj = Instantiate(Resources.Load("CollisionSphere", typeof(GameObject))) as GameObject;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        return obj;
    }    
}
