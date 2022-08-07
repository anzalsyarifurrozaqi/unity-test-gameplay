using UnityEngine;


namespace Character.Function {
    public class FaceToTarget : CharacterFunction {
        const float _turnSpeed = 5.0f;
        public override void RunFunction() {
            var targetPosition = CharacterControl.DATASET.TARGET_DATA.Target.position;
            var transform = CharacterControl.transform;
            Vector3 targetDir = (targetPosition - transform.position).normalized;                        
            var targetRotation = Quaternion.LookRotation(targetDir);

            CharacterControl.transform.rotation = Quaternion.Lerp(CharacterControl.transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }
    }
}

