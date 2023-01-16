using System.Collections.Generic;
using Player;

namespace Dataset
{
    [System.Serializable]
    public class AbilityData
    {
        public Dictionary<CharacterAbility, int> CurrentAbilities = 
            new Dictionary<CharacterAbility, int>();
    }
}