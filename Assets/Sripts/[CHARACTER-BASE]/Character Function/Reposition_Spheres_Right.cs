using UnityEngine;

namespace Character.Base.Function {
    public class Reposition_Spheres_Right : CharacterBaseFunction<ICharacterControl> {
        public override void RunGlobalFunction() {
            CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;
            BoxCollider boxCollider = CharacterControl.BOX_COLLIDER;
            Vector3 PlayerPosition = CharacterControl.transform.position;
            
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
}
