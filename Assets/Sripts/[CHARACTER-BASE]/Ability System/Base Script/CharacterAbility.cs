using UnityEngine;

namespace Player
{
    public abstract class CharacterAbility : ScriptableObject
    {
        public abstract void OnEnter(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo);        
        public abstract void UpdateAbility(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnExit(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo);

    }
}