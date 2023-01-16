using UnityEngine;
using Player;
using Player.Function;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Player/PlayerAbilities/PlayerMove")]
    public class PlayerMove : CharacterAbility
    {
        public override void OnEnter(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Debug.Log("on move");
        }

        public override void UpdateAbility(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
            var control = CharacterState.control;                        

            if (control.Move == Vector2.zero) return;

            control.RunFunction(typeof(CalculateDirection), control.Move);
            // control.RunFunction(typeof(MoveForward));
        }        

        public override void OnExit(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

    }
}
