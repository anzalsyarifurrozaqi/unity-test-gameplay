using UnityEngine;
using Character.Function;

public class Reposition_Spheres_Bottom : CharacterFunction {
    public override void RunFunction() {
        CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;
        BoxCollider boxCollider = CharacterControl.BOX_COLLIDER;
        Vector3 characterPosition = CharacterControl.transform.position;
        
        float bottom = boxCollider.bounds.center.y - (boxCollider.bounds.size.y / 2f);
        float back = boxCollider.bounds.center.z - (boxCollider.bounds.size.z / 2f);
        float front = boxCollider.bounds.center.z + (boxCollider.bounds.size.z / 2f);
        float x = boxCollider.bounds.center.x;

        collisionSpheresData.BottomSpheres[0].transform.localPosition = new Vector3(x, bottom, front) - characterPosition;
        collisionSpheresData.BottomSpheres[1].transform.localPosition = new Vector3(x, bottom, back) - characterPosition;

        float interval = (front - back) / 2;
        
        for (int i = 2; i < collisionSpheresData.BottomSpheres.Length; ++i)
            collisionSpheresData.BottomSpheres[i].transform.localPosition = new Vector3(x, bottom, front - (interval * (i - 1))) - characterPosition;        
    }
}
