using UnityEngine;
using System.Collections.Generic;
using Character.Base;
using Character.Base.Update;
using Enum;

namespace Player.Update {
    public class PlayerUpdateProcessor : MonoBehaviour {
        public Dictionary<System.Type, PlayerUpdate> DicUpdaters = new Dictionary<System.Type, PlayerUpdate>();        
        public Dictionary<System.Type, CharacterBaseUpdate<ICharacterControl>> DicGlobalUpdaters = new Dictionary<System.Type, CharacterBaseUpdate<ICharacterControl>>();

        public PlayerControl control {
            get {
                if (_PlayerControl == null)
                    _PlayerControl = GetComponentInParent<PlayerControl>();

                return _PlayerControl;
            }
        }

        private PlayerControl _PlayerControl;

        public void InitUpdaters() {            
            Debug.Log("Loading Default Player Updates : " + control.gameObject.name);
            SetDefaultUpdates();

            if (control.PlayerSetup.PlayerType == PlayerType.PLAYER)
                AddUpdater(typeof(ManualInput));            
        }

        void SetDefaultUpdates() {
            // AddUpdater(typeof(TargetDistance));
            
            AddGlobalUpdater(typeof(TestGlobalUpdate));
            AddGlobalUpdater(typeof(CollisionSphere));
            AddGlobalUpdater(typeof(BlockingObject));

        }

        void AddUpdater(System.Type UpdaterType) {
            if (UpdaterType.IsSubclassOf(typeof(PlayerUpdate))) {
                _AddUpdater(UpdaterType);
            }

        }

        void AddGlobalUpdater(System.Type UpdaterType) {
            if (UpdaterType.IsSubclassOf(typeof(CharacterBaseUpdate<ICharacterControl>))) {
                _AddGlobalUpdater(UpdaterType);
            }
        }

        void _AddUpdater(System.Type UpdaterType) {
            GameObject obj = new GameObject();
            obj.name = UpdaterType.ToString();
            obj.name = obj.name;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            PlayerUpdate u = obj.AddComponent(UpdaterType) as PlayerUpdate;
            u.PlayerControl = GetComponentInParent<PlayerControl>();

            DicUpdaters.Add(UpdaterType, u);

            u.InitComponent();            
        }

        void _AddGlobalUpdater(System.Type UpdaterType) {
            GameObject obj = new GameObject();
            obj.name = UpdaterType.ToString();
            obj.name = obj.name;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            CharacterBaseUpdate<ICharacterControl> u = obj.AddComponent(UpdaterType) as CharacterBaseUpdate<ICharacterControl>;
            u.CharacterControl = GetComponentInParent<PlayerControl>();

            DicGlobalUpdaters.Add(UpdaterType, u);

            u.InitComponent();            
        }

        public void RunPlayerFixedUpdate() {
            PlayerFixedUpdate(typeof(BlockingObject));
            PlayerFixedUpdate(typeof(ManualInput));
        }

        public void RunPlayerUpdate() {
            PlayerUpdate(typeof(ManualInput));

            PlayerUpdate(typeof(TestGlobalUpdate));
        }

        public void RunPlayerLateUpdate() {
            PlayerLateUpdate(typeof(TargetDistance));
        }

        void PlayerUpdate(System.Type UpdaterType) {            
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
                control.PlayerUpdateProcessor.DicUpdaters[UpdaterType].OnUpdate();            
            
            if (control.PlayerUpdateProcessor.DicGlobalUpdaters.ContainsKey(UpdaterType))
                control.PlayerUpdateProcessor.DicGlobalUpdaters[UpdaterType].OnUpdate();
        }

        void PlayerFixedUpdate(System.Type UpdaterType) {
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))            
                control.PlayerUpdateProcessor.DicUpdaters[UpdaterType].OnFixedUpdate();            
            
            if (control.PlayerUpdateProcessor.DicGlobalUpdaters.ContainsKey(UpdaterType))            
                control.PlayerUpdateProcessor.DicGlobalUpdaters[UpdaterType].OnFixedUpdate(); 
        }

        void PlayerLateUpdate(System.Type UpdaterType) {
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))            
                control.PlayerUpdateProcessor.DicUpdaters[UpdaterType].OnLateUpdate();        

            if (control.PlayerUpdateProcessor.DicGlobalUpdaters.ContainsKey(UpdaterType))            
                control.PlayerUpdateProcessor.DicGlobalUpdaters[UpdaterType].OnLateUpdate();        
        }
    }
}