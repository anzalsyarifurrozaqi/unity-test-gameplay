using UnityEngine;
using Player;
using Character.Base;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Player/PlayerAbilities/Idle")]
    public class Idle : CharacterAbility
    {
        public override void OnEnter(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Debug.Log("on idle");
            CharacterState.control.DATASET.BLOCKING_DATA.FrontBlockingObjects.Clear();
        }
        
        public override void UpdateAbility(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }        

        public override void OnExit(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

    }
}
