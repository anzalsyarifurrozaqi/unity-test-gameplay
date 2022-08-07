using UnityEngine;
using Character;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Character/CharacterAbilities/Idle")]
    public class Idle : CharacterAbility
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Debug.Log("on idle");
        }
        
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }        

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

    }
}
