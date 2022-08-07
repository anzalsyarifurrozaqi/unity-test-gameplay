using System.Collections.Generic;
using UnityEngine;
using Character;
using Enum;
using Manager;

namespace Ablilities {
    [CreateAssetMenu(fileName = "New State", menuName ="Character/CharacterAbilities/TransitionIndexer")]
    public class TransitionIndexer : CharacterAbility
    {
        public int Index;
        public List<TransitionConditionType> transitionConditions = new List<TransitionConditionType>();
        public List<TransitionConditionType> notConditions = new List<TransitionConditionType>();
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Debug.Log("on transitionIndexer");
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
            if (animator.GetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterType.TransitionIndex]) == 0) {
                if (IndexChecker.MakeTransition(characterState.control, transitionConditions)) {
                    if (!IndexChecker.NotCondition(characterState.control, notConditions)) {
                        animator.SetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterType.TransitionIndex], Index);
                    }
                }
            }
        }        

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetInteger(HashManager.Instance.ArrMainParams[(int)MainParameterType.TransitionIndex], 0);
        }

    }
}