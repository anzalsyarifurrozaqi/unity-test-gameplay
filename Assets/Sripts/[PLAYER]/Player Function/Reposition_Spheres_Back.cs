using UnityEngine;
using Player.Function;

public class Reposition_Spheres_Back : PlayerFunction {
    public override void RunFunction() {
        CollisionSpheresData collisionSpheresData = PlayerControl.DATASET.COLLISION_SPHERES_DATA;
        BoxCollider boxCollider = PlayerControl.BOX_COLLIDER;
        Vector3 PlayerPosition = PlayerControl.transform.position;
        
        float back = boxCollider.bounds.center.z - (boxCollider.bounds.size.z / 2f);
        float left = boxCollider.bounds.center.x - (boxCollider.bounds.size.x / 2f);
        float right = boxCollider.bounds.center.x + (boxCollider.bounds.size.x / 2f);
        float y = boxCollider.bounds.center.y;


        collisionSpheresData.BackSpheres[0].transform.localPosition = new Vector3(left, y, back) - PlayerPosition;
        collisionSpheresData.BackSpheres[1].transform.localPosition = new Vector3(right, y, back) - PlayerPosition;

        float interval = (right - left) / 2;
        
        for (int i = 2; i < collisionSpheresData.BackSpheres.Length; ++i)
            collisionSpheresData.BackSpheres[i].transform.localPosition = new Vector3(left + (interval * (i - 1)), y, back) - PlayerPosition;
    }
}
