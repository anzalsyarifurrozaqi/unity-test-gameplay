using UnityEngine;
using Character;
using Character.Function;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Character/CharacterAbilities/PlayerMove")]
    public class PlayerMove : CharacterAbility
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Debug.Log("on move");
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
            var control = characterState.control;                        

            if (control.Move == Vector2.zero) return;

            control.RunFunction(typeof(CalculateDirection), control.Move);
            control.RunFunction(typeof(MoveForward));
        }        

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

    }
}
