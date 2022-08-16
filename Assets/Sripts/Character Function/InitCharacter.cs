using Character.Update;
using Character.Query;
using Manager;

namespace Character.Function
{
    public class InitCharacter : CharacterFunction
    {
        public override void RunFunction(CharacterControl characterControl)
        {
            characterControl.characterSetup = characterControl.GetComponentInChildren<CharacterSetup>();
            characterControl.characterUpdateProcessor = characterControl.GetComponentInChildren<CharacterUpdateProcessor>();
            characterControl.characterQueryProcessor = characterControl.GetComponentInChildren<CharacterQueryProcessor>();   

            characterControl.ANIMATOR.applyRootMotion = true;        

            RegisterCharacter(characterControl);
            InitCharacterStates(characterControl);
        }


        void RegisterCharacter(CharacterControl characterControl)
        {
            if (!CharacterManager.Instance.Characters.Contains(characterControl))
            {
                CharacterManager.Instance.Characters.Add(characterControl);
            }
        }

        void InitCharacterStates(CharacterControl characterControl)
        {
            CharacterState[] characterStates = characterControl.ANIMATOR.GetBehaviours<CharacterState>();

            foreach (CharacterState c in characterStates)
            {
                c.control = characterControl;
            }
        }
    }
}
