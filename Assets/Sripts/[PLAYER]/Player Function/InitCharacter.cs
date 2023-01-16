using Player.Update;
using Player.Query;
using Manager;

namespace Player.Function
{
    public class InitPlayer : PlayerFunction
    {
        public override void RunFunction(PlayerControl PlayerControl)
        {
            PlayerControl.PlayerSetup = PlayerControl.GetComponentInChildren<PlayerSetup>();
            PlayerControl.PlayerUpdateProcessor = PlayerControl.GetComponentInChildren<PlayerUpdateProcessor>();
            PlayerControl.PlayerQueryProcessor = PlayerControl.GetComponentInChildren<PlayerQueryProcessor>();                    

            RegisterPlayer(PlayerControl);
            InitCharacterStates(PlayerControl);
        }


        void RegisterPlayer(PlayerControl PlayerControl)
        {
            if (!PlayerManager.Instance.Players.Contains(PlayerControl))
            {
                PlayerManager.Instance.Players.Add(PlayerControl);
            }
        }

        void InitCharacterStates(PlayerControl PlayerControl)
        {
            CharacterState[] CharacterStates = PlayerControl.ANIMATOR.GetBehaviours<CharacterState>();

            foreach (CharacterState c in CharacterStates)
            {
                c.control = PlayerControl;
            }
        }
    }
}
