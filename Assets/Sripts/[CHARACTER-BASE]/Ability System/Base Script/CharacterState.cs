using UnityEngine;
using Dataset;

namespace Player
{
    public class CharacterState : StateMachineBehaviour
    {
        public PlayerControl control;
        
        [Space(10)]
        public CharacterAbility[] ArrAbilities;
        
        public PlayerDatasets DATASET => control.DATASET;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {            
            EnterAll(this, animator, stateInfo, ArrAbilities);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {            
            UpdateAll(this, animator, stateInfo, ArrAbilities);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {            
            ExitAll(this, animator, stateInfo, ArrAbilities);
        }

        public void EnterAll(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo, CharacterAbility[] AbilityList)
        {
            for (int i = 0; i < AbilityList.Length; i++)
            {                
                AbilityList[i].OnEnter(CharacterState, animator, stateInfo);

                if (control.DATASET.ABILITY_DATA.CurrentAbilities.ContainsKey(AbilityList[i]))
                {
                    control.DATASET.ABILITY_DATA.CurrentAbilities[AbilityList[i]] += 1;
                }
                else
                {
                    control.DATASET.ABILITY_DATA.CurrentAbilities.Add(AbilityList[i], 1);
                }
            }
        }

        public void UpdateAll(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo, CharacterAbility[] AbilityList)
        {
            for (int i = 0; i < AbilityList.Length; i++)
            {
                AbilityList[i].UpdateAbility(CharacterState, animator, stateInfo);
            }
        }

        public void ExitAll(CharacterState CharacterState, Animator animator, AnimatorStateInfo stateInfo, CharacterAbility[] AbilityList)
        {
            for (int i = 0; i < AbilityList.Length; i++)
            {
                AbilityList[i].OnExit(CharacterState, animator, stateInfo);

                if (control.DATASET.ABILITY_DATA.CurrentAbilities.ContainsKey(AbilityList[i]))
                {
                    control.DATASET.ABILITY_DATA.CurrentAbilities[AbilityList[i]] -= 1;
                }

                if (control.DATASET.ABILITY_DATA.CurrentAbilities[AbilityList[i]] <= 0)
                {
                    control.DATASET.ABILITY_DATA.CurrentAbilities.Remove(AbilityList[i]);
                }
            }
        }        
    }
}