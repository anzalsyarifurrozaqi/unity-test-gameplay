using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using Manager;
using Enum;

namespace Zombie.Update {
    // doing for testing
    public class ZombieMove : ZombieUpdate {        
        private Vector2 _moveDirection = Vector2.zero; 
        private static float _timeSpeed = 10.0f;
        private Quaternion _targetRotation = Quaternion.identity; 
        public override void InitComponent() {
            RandomizeMovePointObject(ref _moveDirection);
            StartCoroutine(DoRandomize());
        }

        private void RandomizeMovePointObject(ref Vector2 position) {
            position.x = Mathf.RoundToInt( Random.Range(-1f, 1f));
            position.y = Mathf.RoundToInt(Random.Range(-1f, 1f));
        }

        public override void OnUpdate() {
            Vector3 inputWorldPosition;
            Vector3 target;
            Vector3 angle;            
            
            inputWorldPosition = new Vector3(_moveDirection.x, 0.0f, _moveDirection.y);
            target = Vector3.up - inputWorldPosition;
            angle = Quaternion.LookRotation(target).eulerAngles;
            _targetRotation = Quaternion.Lerp(
                ZombieControl.transform.rotation, 
                Quaternion.Euler(0.0f, angle.y, 0.0f), 
                Time.deltaTime * _timeSpeed
            );

            ZombieControl.ANIMATOR.SetFloat(HashManager.Instance.ArrMainParams[(int)MainParameterType.MoveCounter], .5f);
        }

        public override void OnFixedUpdate()
        {            
            ZombieControl.RIGID_BODY.MoveRotation(_targetRotation);
        }

        private IEnumerator DoRandomize() {
            while (true) {
                yield return new WaitForEndOfFrame();
                yield return new WaitForSeconds(7f);

                RandomizeMovePointObject(ref _moveDirection);                
            }
        }
    }
}
