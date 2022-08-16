using UnityEngine;
using Character;
using Character.Update;
using System.Collections.Generic;

namespace Manager
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public List<CharacterControl> Characters = new List<CharacterControl>();        

        [SerializeField]
        CharacterControl[] ArrCharacters = null;

        #region PULBIC METHOD
        public CharacterControl GetCharacter(GameObject obj)
        {
            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                if (ArrCharacters[i].gameObject == obj)
                {
                    return ArrCharacters[i];
                }
            }

            return null;
        }

        public CharacterControl GetPlayableCharacter()
        {
            foreach (CharacterControl control in Characters)
            {
                if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(typeof(ManualInput)))
                {
                    return control;
                }
            }

            return null;
        }

        public bool IsCharacterPlayable(GameObject characterObj)
        {
            foreach (CharacterControl control in Characters)
            {
                if (control.gameObject == characterObj)
                {
                    if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(typeof(ManualInput)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region  PRIVATE METHOD
        private void Awake() {
            
        }
        private void Update()
        {
            InitCharacterArray();

            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                ArrCharacters[i].CharacterUpdate();
            }
        }

        private void FixedUpdate()
        {
            InitCharacterArray();

            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                ArrCharacters[i].CharacterFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            InitCharacterArray();

            for (int i = 0; i < ArrCharacters.Length; i++)
            {
                ArrCharacters[i].CharacterLateUpdate();
            }
        }

        private void OnAnimatorMove() {
            InitCharacterArray();

            for (int i = 0; i < ArrCharacters.Length; i++) {
                // ArrCharacters[i].CharacterIbAnimatorMove();
            }
        }

        #endregion

        #region UTIL METHOD
        void InitCharacterArray()
        {            
            if (ArrCharacters == null || ArrCharacters.Length != Characters.Count)
            {
                ArrCharacters = new CharacterControl[Characters.Count];

                for (int i = 0; i < Characters.Count; i++)
                {
                    ArrCharacters[i] = Characters[i];
                }
            }
        }
        #endregion
    }
}


// TODO : use onanimatormove