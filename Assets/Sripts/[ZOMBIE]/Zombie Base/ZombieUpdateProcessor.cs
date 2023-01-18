using UnityEngine;
using System.Collections.Generic;
using Character.Base;
using Character.Base.Update;
using Enum;
using System;

namespace Zombie.Update {
    public class ZombieUpdateProcessor : CharacterBaseUpdateProcessor {
        public Dictionary<System.Type, ZombieUpdate> DicUpdaters = new Dictionary<System.Type, ZombieUpdate>();
        public Dictionary<System.Type, CharacterBaseUpdate<ICharacterControl>> DicGlobalUpdaters = new Dictionary<System.Type, CharacterBaseUpdate<ICharacterControl>>();

        private ZombieControl ZombieControl {
            get {
                if (_zombieControl == null) {
                    _zombieControl = GetComponentInParent<ZombieControl>();                    
                }
                return _zombieControl;
            }
        }
        private ZombieControl _zombieControl;

        public override void InitUpdaters()
        {
            Debug.Log("Loading Default Player Updates : " + ZombieControl.gameObject.name);
            SetDefaultUpdates();
        }

        protected override void SetDefaultUpdates()
        {
            AddGlobalUpdater(typeof(TestGlobalUpdate));
            AddGlobalUpdater(typeof(CollisionSphere));
            AddGlobalUpdater(typeof(BlockingObject));
        }

        public override void RunCharacterUpdate()
        {
            CharacterUpdate(typeof(BlockingObject));
            CharacterUpdate(typeof(TestGlobalUpdate));
        }

        public override void RunCharacterFixedUpdate()
        {
            
        }

        public override void RunCharacterLateUpdate()
        {
            
        }

        protected override void AddUpdater(Type type)
        {
            if (type.IsSubclassOf(typeof(ZombieUpdate))) {
                _AddUpdater(type);
            }
        }

        // TODO: maybe can use base
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
            ZombieUpdate u = obj.AddComponent(type) as ZombieUpdate;
            u.ZombieControl = GetComponentInParent<ZombieControl>();

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
            u.CharacterControl = GetComponentInParent<ZombieControl>();

            DicGlobalUpdaters.Add(type, u);

            u.InitComponent();
        }

        protected override void CharacterUpdate(Type type)
        {
            if (ZombieControl.ZombieUpdateProcessor.DicUpdaters.ContainsKey(type))
                ZombieControl.ZombieUpdateProcessor.DicUpdaters[type].OnUpdate();            

            if (ZombieControl.ZombieUpdateProcessor.DicGlobalUpdaters.ContainsKey(type))
                ZombieControl.ZombieUpdateProcessor.DicGlobalUpdaters[type].OnUpdate();
        }

        protected override void CharacterFixedUpdate(Type type)
        {
            if (ZombieControl.ZombieUpdateProcessor.DicUpdaters.ContainsKey(type))            
                ZombieControl.ZombieUpdateProcessor.DicUpdaters[type].OnFixedUpdate();            

            if (ZombieControl.ZombieUpdateProcessor.DicGlobalUpdaters.ContainsKey(type))            
                ZombieControl.ZombieUpdateProcessor.DicGlobalUpdaters[type].OnFixedUpdate(); 
        }

        protected override void CharacterLateUpdate(Type type)
        {
            if (ZombieControl.ZombieUpdateProcessor.DicUpdaters.ContainsKey(type))            
                ZombieControl.ZombieUpdateProcessor.DicUpdaters[type].OnLateUpdate();        

            if (ZombieControl.ZombieUpdateProcessor.DicGlobalUpdaters.ContainsKey(type))            
                ZombieControl.ZombieUpdateProcessor.DicGlobalUpdaters[type].OnLateUpdate();  
        }
    }
}
