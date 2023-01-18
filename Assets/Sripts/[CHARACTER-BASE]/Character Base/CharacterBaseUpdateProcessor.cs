using UnityEngine;

namespace Character.Base.Update {
    public abstract class CharacterBaseUpdateProcessor : MonoBehaviour
    {
        
        public abstract void InitUpdaters();
        protected abstract void SetDefaultUpdates();
        public abstract void RunCharacterUpdate();
        public abstract void RunCharacterFixedUpdate();
        public abstract void RunCharacterLateUpdate();
        protected abstract void AddUpdater(System.Type type);
        protected abstract void AddGlobalUpdater(System.Type type);
        protected abstract void _AddUpdater(System.Type type);
        protected abstract void _AddGlobalUpdater(System.Type type);
        protected abstract void CharacterUpdate(System.Type type);
        protected abstract void CharacterFixedUpdate(System.Type type);
        protected abstract void CharacterLateUpdate(System.Type type);
    }
}
