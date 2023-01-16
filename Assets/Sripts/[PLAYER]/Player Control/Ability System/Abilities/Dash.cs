using UnityEngine;
using Player;
using Player.Function;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName = "Player/PlayerAbilities/Dash")]
    public class Dash : CharacterAbility
    {
        public override void OnEnter(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Debug.Log("dash");
        }
        public override void UpdateAbility(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterState.control.RunFunction(typeof(DashForward));
        }
        public override void OnExit(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
