using UnityEngine;
using Character;
using Character.Function;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Character/CharacterAbilities/PlayerAttack")]
    public class PlayerAttack : CharacterAbility
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.control.RunFunction(typeof(FaceToTarget));            
            characterState.control.RunFunction(typeof(DashForward));
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

    }
}
