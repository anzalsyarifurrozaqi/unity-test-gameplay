using UnityEngine;
using Character.Function;

public class Reposition_Spheres_Back : CharacterFunction {
    public override void RunFunction() {
        CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;
        BoxCollider boxCollider = CharacterControl.BOX_COLLIDER;
        Vector3 characterPosition = CharacterControl.transform.position;
        
        float back = boxCollider.bounds.center.z - (boxCollider.bounds.size.z / 2f);
        float left = boxCollider.bounds.center.x - (boxCollider.bounds.size.x / 2f);
        float right = boxCollider.bounds.center.x + (boxCollider.bounds.size.x / 2f);
        float y = boxCollider.bounds.center.y;


        collisionSpheresData.BackSpheres[0].transform.localPosition = new Vector3(left, y, back) - characterPosition;
        collisionSpheresData.BackSpheres[1].transform.localPosition = new Vector3(right, y, back) - characterPosition;

        float interval = (right - left) / 2;
        
        for (int i = 2; i < collisionSpheresData.BackSpheres.Length; ++i)
            collisionSpheresData.BackSpheres[i].transform.localPosition = new Vector3(left + (interval * (i - 1)), y, back) - characterPosition;
    }
}
