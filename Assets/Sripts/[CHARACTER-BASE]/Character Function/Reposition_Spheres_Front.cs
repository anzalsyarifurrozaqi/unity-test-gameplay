using UnityEngine;

namespace Character.Base.Function {
    public class Reposition_Spheres_Front : CharacterBaseFunction<ICharacterControl> {    
        public override void RunGlobalFunction() {                        
            CollisionSpheresData collisionSpheresData = CharacterControl.DATASET.COLLISION_SPHERES_DATA;
            BoxCollider boxCollider = CharacterControl.BOX_COLLIDER;
            Vector3 PlayerPosition = CharacterControl.transform.position;
            
            float front = boxCollider.bounds.center.z + (boxCollider.bounds.size.z / 2f);
            float left = boxCollider.bounds.center.x - (boxCollider.bounds.size.x / 2f);
            float right = boxCollider.bounds.center.x + (boxCollider.bounds.size.x / 2f);
            float y = boxCollider.bounds.center.y;


            collisionSpheresData.FrontSpheres[0].transform.localPosition = new Vector3(left, y, front) - PlayerPosition;
            collisionSpheresData.FrontSpheres[1].transform.localPosition = new Vector3(right, y, front) - PlayerPosition;

            float interval = (right - left) / 2;
            
            for (int i = 2; i < collisionSpheresData.FrontSpheres.Length; ++i)
                collisionSpheresData.FrontSpheres[i].transform.localPosition = new Vector3(left + (interval * (i - 1)), y, front) - PlayerPosition;        
        }
    }
}
