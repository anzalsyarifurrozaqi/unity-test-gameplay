using UnityEngine;
using System.Collections.Generic;
using Enum;

namespace Character.Update
{
    public class CharacterUpdateProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, CharacterUpdate> DicUpdaters = new Dictionary<System.Type, CharacterUpdate>();        

        public CharacterControl control
        {
            get
            {
                if (_characterControl == null)
                {
                    _characterControl = GetComponentInParent<CharacterControl>();
                }

                return _characterControl;
            }
        }

        private CharacterControl _characterControl;

        public void InitUpdaters()
        {            
            Debug.Log("Loading Default Character Updates : " + control.gameObject.name);
            SetDefaultUpdates();

            if (control.characterSetup.CharacterType == CharacterType.PLAYER)
            {
                AddUpdater(typeof(ManualInput));
            }          
        }

        void SetDefaultUpdates()
        {
            AddUpdater(typeof(TargetDistance));
            AddUpdater(typeof(CollisionSphere));
        }

        void AddUpdater(System.Type UpdaterType)
        {
            if (UpdaterType.IsSubclassOf(typeof(CharacterUpdate)))
            {
                _AddUpdater(UpdaterType);
            }
        }

        void _AddUpdater(System.Type UpdaterType)
        {
            GameObject obj = new GameObject();
            obj.name = UpdaterType.ToString();
            obj.name = obj.name;
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            CharacterUpdate u = obj.AddComponent(UpdaterType) as CharacterUpdate;
            u.CharacterControl = GetComponentInParent<CharacterControl>();

            DicUpdaters.Add(UpdaterType, u);

            u.InitComponent();            
        }

        public void RunCharacterFixedUpdate()
        {
        }

        public void RunCharacterUpdate()
        {
            CharacterUpdate(typeof(ManualInput));
        }

        public void RunCharacterLateUpdate()
        {
            CharacterLateUpdate(typeof(TargetDistance));
        }

        void CharacterUpdate(System.Type UpdaterType)
        {
            
            if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                control.characterUpdateProcessor.DicUpdaters[UpdaterType].OnUpdate();
            }
        }

        void CharacterFixedUpdate(System.Type UpdaterType)
        {
            if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                control.characterUpdateProcessor.DicUpdaters[UpdaterType].OnFixedUpdate();
            }
        }

        void CharacterLateUpdate(System.Type UpdaterType)
        {
            if (control.characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                control.characterUpdateProcessor.DicUpdaters[UpdaterType].OnLateUpdate();
            }
        }
    }
}