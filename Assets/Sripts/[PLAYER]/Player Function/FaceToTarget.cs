using UnityEngine;


namespace Player.Function {
    public class FaceToTarget : PlayerFunction {
        const float _turnSpeed = 5.0f;
        public override void RunFunction() {
            var targetPosition = PlayerControl.DATASET.TARGET_DATA.Target.position;
            var transform = PlayerControl.transform;
            Vector3 targetDir = (targetPosition - transform.position).normalized;                        
            var targetRotation = Quaternion.LookRotation(targetDir);

            PlayerControl.transform.rotation = Quaternion.Lerp(PlayerControl.transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }
    }
}

