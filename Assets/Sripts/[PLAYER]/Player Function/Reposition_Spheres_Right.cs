using UnityEngine;
using Player.Function;

public class Reposition_Spheres_Right : PlayerFunction {
    public override void RunFunction() {
        CollisionSpheresData collisionSpheresData = PlayerControl.DATASET.COLLISION_SPHERES_DATA;
        BoxCollider boxCollider = PlayerControl.BOX_COLLIDER;
        Vector3 PlayerPosition = PlayerControl.transform.position;
        
        float right = boxCollider.bounds.center.x + (boxCollider.bounds.size.x / 2f);
        float back = boxCollider.bounds.center.z - (boxCollider.bounds.size.z / 2f);
        float front = boxCollider.bounds.center.z + (boxCollider.bounds.size.z / 2f);
        float y = boxCollider.bounds.center.y;


        collisionSpheresData.RightSpheres[0].transform.localPosition = new Vector3(right, y, front) - PlayerPosition;
        collisionSpheresData.RightSpheres[1].transform.localPosition = new Vector3(right, y, back) - PlayerPosition;

        float interval = (front - back) / 2;
        
        for (int i = 2; i < collisionSpheresData.RightSpheres.Length; ++i)
            collisionSpheresData.RightSpheres[i].transform.localPosition = new Vector3(right, y, front - (interval * (i - 1))) - PlayerPosition;
    }
}