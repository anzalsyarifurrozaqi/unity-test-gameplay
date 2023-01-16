using System.Collections.Generic;
using UnityEngine;
using Player;
using Enum;
using Manager;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Player/PlayerAbilities/TransitionIndexer")]
    public class TransitionIndexer : CharacterAbility
    {
        public int Index;
        public List<TransitionConditionType> transitionConditions = new List<TransitionConditionType>();
        public List<TransitionConditionType> notConditions = new List<TransitionConditionType>();
        public override void OnEnter(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo) {
            
        }

        public override void UpdateAbility(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo) {            
            if (animator.GetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterType.TransitionIndex]) == 0) {
                if (IndexChecker.MakeTransition(CharacterState.control, transitionConditions)) {
                    if (!IndexChecker.NotCondition(CharacterState.control, notConditions)) {
                        animator.SetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterType.TransitionIndex], Index);
                    }
                }
            }
        }        

        public override void OnExit(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo) {
            animator.SetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterType.TransitionIndex], 0);
        }

    }
}