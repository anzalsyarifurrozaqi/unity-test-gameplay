
using System.Collections.Generic;

namespace Character.Base.Dataset
{
    [System.Serializable]
    public class AbilityData
    {
        public Dictionary<CharacterAbility, int> CurrentAbilities = 
            new Dictionary<CharacterAbility, int>();
    }
}