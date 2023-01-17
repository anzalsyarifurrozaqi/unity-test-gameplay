using UnityEngine;
using Player.Function;
using Character.Base;

public class Reposition_Spheres_Left : CharacterBaseFunction<ICharacterControl> {
    public override void RunGlobalFunction() {
        CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;
        BoxCollider boxCollider = CharacterControl.BOX_COLLIDER;
        Vector3 PlayerPosition = CharacterControl.transform.position;
        
        float left = boxCollider.bounds.center.x - (boxCollider.bounds.size.x / 2f);
        float back = boxCollider.bounds.center.z - (boxCollider.bounds.size.z / 2f);
        float front = boxCollider.bounds.center.z + (boxCollider.bounds.size.z / 2f);
        float y = boxCollider.bounds.center.y;


        collisionSpheresData.LeftSpheres[0].transform.localPosition = new Vector3(left, y, front) - PlayerPosition;
        collisionSpheresData.LeftSpheres[1].transform.localPosition = new Vector3(left, y, back) - PlayerPosition;

        float interval = (front - back) / 2;
        
        for (int i = 2; i < collisionSpheresData.LeftSpheres.Length; ++i)
            collisionSpheresData.LeftSpheres[i].transform.localPosition = new Vector3(left, y, front - (interval * (i - 1))) - PlayerPosition;
    }
}
