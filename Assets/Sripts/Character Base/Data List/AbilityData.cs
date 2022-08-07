using System.Collections.Generic;
using Character;

namespace Dataset
{
    [System.Serializable]
    public class AbilityData
    {
        public Dictionary<CharacterAbility, int> CurrentAbilities = 
            new Dictionary<CharacterAbility, int>();
    }
}