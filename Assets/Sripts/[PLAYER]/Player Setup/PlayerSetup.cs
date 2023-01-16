using UnityEngine;
using Enum;
using Manager.Attack;

namespace Player
{
    public class PlayerSetup : MonoBehaviour
    {
        [Space(15)] public PlayerType PlayerType;
        [Space(15)] public AttackPartSetup attackPartSetup;

        private PlayerControl _control;
        
        private void Awake()
        {
            _control = GetComponentInParent<PlayerControl>();
        }
    }
}