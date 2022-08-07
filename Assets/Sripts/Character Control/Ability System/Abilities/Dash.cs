using UnityEngine;
using Character;
using Character.Function;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName = "Character/CharacterAbilities/Dash")]
    public class Dash : CharacterAbility
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Debug.Log("dash");
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.control.RunFunction(typeof(DashForward));
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
