using UnityEngine;
using System.Collections.Generic;
using Character.Base;
using Character.Base.Update;
using Enum;
using System;

namespace Player.Update {
    public class PlayerUpdateProcessor : CharacterBaseUpdateProcessor {
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

        public override void InitUpdaters()
        {
            Debug.Log("Loading Default Player Updates : " + control.gameObject.name);
            SetDefaultUpdates();

            if (control.PlayerSetup.PlayerType == PlayerType.PLAYER)
                AddUpdater(typeof(ManualInput));            
        }

        protected override void SetDefaultUpdates()
        {
            // AddUpdater(typeof(TargetDistance));

            AddGlobalUpdater(typeof(TestGlobalUpdate));
            AddGlobalUpdater(typeof(CollisionSphere));
            AddGlobalUpdater(typeof(BlockingObject));
        }

        public override void RunCharacterUpdate()
        {
            CharacterUpdate(typeof(ManualInput));
            CharacterUpdate(typeof(BlockingObject));
            CharacterUpdate(typeof(TestGlobalUpdate));
        }

        public override void RunCharacterFixedUpdate()
        {
            CharacterFixedUpdate(typeof(ManualInput));
        }

        public override void RunCharacterLateUpdate()
        {
            CharacterLateUpdate(typeof(TargetDistance));            
        }

        protected override void AddUpdater(Type type)
        {
            if (type.IsSubclassOf(typeof(PlayerUpdate))) {
                _AddUpdater(type);
            }
        }

        protected override void AddGlobalUpdater(Type type)
        {
            if (type.IsSubclassOf(typeof(CharacterBaseUpdate<ICharacterControl>))) {
                _AddGlobalUpdater(type);
            }
        }

        protected override void _AddUpdater(Type type)
        {
            GameObject obj = new GameObject();
            obj.name = type.ToString();
            obj.name = obj.name;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            PlayerUpdate u = obj.AddComponent(type) as PlayerUpdate;
            u.PlayerControl = GetComponentInParent<PlayerControl>();

            DicUpdaters.Add(type, u);

            u.InitComponent();            
        }

        protected override void _AddGlobalUpdater(Type type)
        {
            GameObject obj = new GameObject();
            obj.name = type.ToString();
            obj.name = obj.name;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            CharacterBaseUpdate<ICharacterControl> u = obj.AddComponent(type) as CharacterBaseUpdate<ICharacterControl>;
            u.CharacterControl = GetComponentInParent<PlayerControl>();

            DicGlobalUpdaters.Add(type, u);

            u.InitComponent();            
        }

        protected override void CharacterUpdate(Type type)
        {
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(type))
                control.PlayerUpdateProcessor.DicUpdaters[type].OnUpdate();            

            if (control.PlayerUpdateProcessor.DicGlobalUpdaters.ContainsKey(type))
                control.PlayerUpdateProcessor.DicGlobalUpdaters[type].OnUpdate();
        }

        protected override void CharacterFixedUpdate(Type type)
        {
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(type))            
                control.PlayerUpdateProcessor.DicUpdaters[type].OnFixedUpdate();            

            if (control.PlayerUpdateProcessor.DicGlobalUpdaters.ContainsKey(type))            
                control.PlayerUpdateProcessor.DicGlobalUpdaters[type].OnFixedUpdate(); 
        }

        protected override void CharacterLateUpdate(Type type)
        {
            if (control.PlayerUpdateProcessor.DicUpdaters.ContainsKey(type))            
                control.PlayerUpdateProcessor.DicUpdaters[type].OnLateUpdate();        

            if (control.PlayerUpdateProcessor.DicGlobalUpdaters.ContainsKey(type))            
                control.PlayerUpdateProcessor.DicGlobalUpdaters[type].OnLateUpdate();  
        } 
    }
}