using UnityEngine;
using Player.Function;
using Character.Base;

public class Reposition_Spheres_Bottom : CharacterBaseFunction<ICharacterControl> {
    public override void RunGlobalFunction() {
        CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;
        BoxCollider boxCollider = CharacterControl.BOX_COLLIDER;
        Vector3 PlayerPosition = CharacterControl.transform.position;
        
        float bottom = boxCollider.bounds.center.y - (boxCollider.bounds.size.y / 2f);
        float back = boxCollider.bounds.center.z - (boxCollider.bounds.size.z / 2f);
        float front = boxCollider.bounds.center.z + (boxCollider.bounds.size.z / 2f);
        float x = boxCollider.bounds.center.x;

        collisionSpheresData.BottomSpheres[0].transform.localPosition = new Vector3(x, bottom, front) - PlayerPosition;
        collisionSpheresData.BottomSpheres[1].transform.localPosition = new Vector3(x, bottom, back) - PlayerPosition;

        float interval = (front - back) / 2;
        
        for (int i = 2; i < collisionSpheresData.BottomSpheres.Length; ++i)
            collisionSpheresData.BottomSpheres[i].transform.localPosition = new Vector3(x, bottom, front - (interval * (i - 1))) - PlayerPosition;        
    }
}
