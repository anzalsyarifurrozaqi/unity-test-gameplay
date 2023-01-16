using UnityEngine;
using System.Collections.Generic;
using Enum;

namespace Player.Update
{
    public class PlayerUpdateProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, PlayerUpdate> DicUpdaters = new Dictionary<System.Type, PlayerUpdate>();        

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
            AddUpdater(typeof(TargetDistance));
            AddUpdater(typeof(CollisionSphere));
            AddUpdater(typeof(BlockingObject));
        }

        void AddUpdater(System.Type UpdaterType) {
            if (UpdaterType.IsSubclassOf(typeof(PlayerUpdate))) {
                _AddUpdater(UpdaterType);
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

        public void RunPlayerFixedUpdate() {
            PlayerFixedUpdate(typeof(BlockingObject));
            PlayerFixedUpdate(typeof(ManualInput));
        }

        public void RunPlayerUpdate() {
            PlayerUpdate(typeof(ManualInput));
        }

        public void RunPlayerLateUpdate() {
            PlayerLateUpdate(typeof(TargetDistance));
        }

        void PlayerUpdate(System.Type UpdaterType) {            
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
                control.PlayerUpdateProcessor.DicUpdaters[UpdaterType].OnUpdate();            
        }

        void PlayerFixedUpdate(System.Type UpdaterType) {
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))            
                control.PlayerUpdateProcessor.DicUpdaters[UpdaterType].OnFixedUpdate();            
        }

        void PlayerLateUpdate(System.Type UpdaterType) {
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))            
                control.PlayerUpdateProcessor.DicUpdaters[UpdaterType].OnLateUpdate();        
        }
    }
}