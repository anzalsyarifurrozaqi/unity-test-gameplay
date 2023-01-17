using UnityEngine;
using Manager;
using Character.Base;

namespace Zombie.Function {
    public class InitZombie : ZombieFunction {
       public override void RunFunction(ZombieControl ZombieControl)
        {
            ZombieControl.ZombieSetup = ZombieControl.GetComponentInChildren<ZombieSetup>();
            ZombieControl.ZombieUpdateProcessor = ZombieControl.GetComponentInChildren<ZombieUpdateProcessor>();
            ZombieControl.ZombieQueryProcessor = ZombieControl.GetComponentInChildren<ZombieQueryProcessor>();                    

            RegisterPlayer(ZombieControl);
            InitCharacterStates(ZombieControl);
        }


        void RegisterPlayer(ZombieControl ZombieControl)
        {
            if (!CharacterManager.Instance.Zombies.Contains(ZombieControl))
            {
                CharacterManager.Instance.Zombies.Add(ZombieControl);
            }
        }

        void InitCharacterStates(ZombieControl ZombieControl)
        {
            CharacterState[] CharacterStates = ZombieControl.ANIMATOR.GetBehaviours<CharacterState>();

            foreach (CharacterState c in CharacterStates)
            {
                c.control = ZombieControl;
            }
        }
    }
}
