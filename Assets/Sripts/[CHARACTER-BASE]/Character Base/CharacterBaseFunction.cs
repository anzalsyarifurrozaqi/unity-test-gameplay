using UnityEngine;

public class CharacterBaseFunction<TCharacterControl> : MonoBehaviour where TCharacterControl : ICharacterControl {    
    public TCharacterControl CharacterControl { get; set; }

    public virtual void RunGlobalFunction() {
        throw new System.NotImplementedException();
    }
}
