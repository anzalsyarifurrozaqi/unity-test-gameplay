using UnityEngine;
using Player;
using Player.Update;
using Zombie;
using System.Collections.Generic;

namespace Manager {
    public class CharacterManager : Singleton<CharacterManager> {
        public List<PlayerControl> Players = new List<PlayerControl>();
        public List<ZombieControl> Zombies = new List<ZombieControl>();

        [SerializeField]
        PlayerControl[] ArrPlayers = null;
        [SerializeField]
        ZombieControl[] ArrZombies = null;

        #region PULBIC METHOD
        public PlayerControl GetPlayer(GameObject obj) {
            for (int i = 0; i < ArrPlayers.Length; ++i) {
                if (ArrPlayers[i].gameObject == obj) {
                    return ArrPlayers[i];
                }
            }

            return null;
        }

        public PlayerControl GetPlayablePlayer() {
            foreach (PlayerControl control in Players) {
                if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(typeof(ManualInput))) {
                    return control;
                }
            }

            return null;
        }

        public bool IsPlayerPlayable(GameObject PlayerObj) {
            foreach (PlayerControl control in Players) {
                if (control.gameObject == PlayerObj) {
                    if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(typeof(ManualInput))) {
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
        private void Update() {
            InitPlayerArray();

            for (int i = 0; i < ArrPlayers.Length; ++i) {
                ArrPlayers[i].CharacterUpdate();
            }

            InitZombieArray();

            for (int i = 0; i < ArrZombies.Length; ++i) {
                ArrZombies[i].CharacterUpdate();
            }
        }

        private void FixedUpdate() {
            InitPlayerArray();

            for (int i = 0; i < ArrPlayers.Length; ++i) {
                ArrPlayers[i].CharacterFixedUpdate();
            }

            InitZombieArray();

            for (int i = 0; i < ArrZombies.Length; ++i) {
                ArrZombies[i].CharacterFixedUpdate();
            }
        }

        private void LateUpdate() {
            InitPlayerArray();

            for (int i = 0; i < ArrPlayers.Length; ++i) {
                ArrPlayers[i].CharacterLateUpdate();
            }

            InitZombieArray();

            for (int i = 0; i < ArrZombies.Length; ++i) {
                ArrZombies[i].CharacterLateUpdate();
            }
        }

        private void OnAnimatorMove() {
            // InitPlayerArray();

            // for (int i = 0; i < ArrPlayers.Length; i++) {
            //     // ArrPlayers[i].PlayerIbAnimatorMove();
            // }
        }

        #endregion

        #region UTIL METHOD
        void InitPlayerArray()
        {            
            if (ArrPlayers == null || ArrPlayers.Length != Players.Count)
            {
                ArrPlayers = new PlayerControl[Players.Count];

                for (int i = 0; i < Players.Count; i++)
                {
                    ArrPlayers[i] = Players[i];
                }
            }
        }

        void InitZombieArray() {
            if (ArrZombies == null || ArrZombies.Length != Zombies.Count) {
                ArrZombies = new ZombieControl[Zombies.Count];

                for (int i = 0; i < Zombies.Count; ++i) {
                    ArrZombies[i] = Zombies[i];
                }
            }
        }
        #endregion
    }
}


// TODO : use onanimatormove