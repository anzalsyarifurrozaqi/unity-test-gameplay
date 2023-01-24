using UnityEngine;
using Character.Base;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Player/PlayerAbilities/Attack")]
    public class Attack : CharacterAbility {
        public bool MusCollide;
        public float Damage;
        public override void OnEnter(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo) {
            Debug.Log("attack enter");
        }
        public override void UpdateAbility(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo) {
            Debug.Log("attack update");
        }
        public override void OnExit(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo) {
            Debug.Log("attack exit");
        }
    }
}
