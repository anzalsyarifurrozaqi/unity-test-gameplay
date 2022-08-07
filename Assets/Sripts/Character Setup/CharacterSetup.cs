using UnityEngine;
using Enum;
using Manager.Attack;

namespace Character
{
    public class CharacterSetup : MonoBehaviour
    {
        [Space(15)] public CharacterType CharacterType;
        [Space(15)] public AttackPartSetup attackPartSetup;

        private CharacterControl _control;
        
        private void Awake()
        {
            _control = GetComponentInParent<CharacterControl>();
        }
    }
}