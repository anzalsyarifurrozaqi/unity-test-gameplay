using UnityEngine;

namespace Character.Base {
    public class CharacterBaseQuery<TCharacterControl> : MonoBehaviour where TCharacterControl : ICharacterControl {
        public TCharacterControl CharacterControl;
    }
}
