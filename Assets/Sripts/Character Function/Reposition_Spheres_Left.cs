using UnityEngine;
using Character.Function;

public class Reposition_Spheres_Left : CharacterFunction {
    public override void RunFunction() {
        CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;
        BoxCollider boxCollider = CharacterControl.BOX_COLLIDER;
        Vector3 characterPosition = CharacterControl.transform.position;
        
        float left = boxCollider.bounds.center.x - (boxCollider.bounds.size.x / 2f);
        float back = boxCollider.bounds.center.z - (boxCollider.bounds.size.z / 2f);
        float front = boxCollider.bounds.center.z + (boxCollider.bounds.size.z / 2f);
        float y = boxCollider.bounds.center.y;


        collisionSpheresData.LeftSpheres[0].transform.localPosition = new Vector3(left, y, front) - characterPosition;
        collisionSpheresData.LeftSpheres[1].transform.localPosition = new Vector3(left, y, back) - characterPosition;

        float interval = (front - back) / 2;
        
        for (int i = 2; i < collisionSpheresData.LeftSpheres.Length; ++i)
            collisionSpheresData.LeftSpheres[i].transform.localPosition = new Vector3(left, y, front - (interval * (i - 1))) - characterPosition;
    }
}
