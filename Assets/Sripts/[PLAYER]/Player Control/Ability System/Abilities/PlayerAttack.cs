using UnityEngine;
using Player;
using Player.Function;
using Character.Base;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Player/PlayerAbilities/PlayerAttack")]
    public class PlayerAttack : CharacterAbility
    {
        public override void OnEnter(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            // CharacterState.control.RunFunction(typeof(FaceToTarget));            
            // CharacterState.control.RunFunction(typeof(DashForward));
        }

        public override void OnExit(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

    }
}
