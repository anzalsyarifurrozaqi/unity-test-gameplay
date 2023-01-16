using UnityEngine;
using System.Collections.Generic;

namespace Player.Function
{
    public class PlayerFunctionProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, PlayerFunction> DicFunctions = new Dictionary<System.Type, PlayerFunction>();
        public Dictionary<System.Type, CharacterBaseFunction<ICharacterControl>> DicGlobalFunctions = new Dictionary<System.Type, CharacterBaseFunction<ICharacterControl>>();

        private void Start()
        {            
            Debug.Log("Loading Default Player Function: " + GetComponentInParent<PlayerControl>().name);
            SetDeafaultFunction();

            PlayerControl control = GetComponentInParent<PlayerControl>();
            control.InitalizePlayer();
        }

        void SetDeafaultFunction()
        {
            AddFunction(typeof(InitPlayer));
            // AddFunction(typeof(CalculateDirection));
            // AddFunction(typeof(MoveForward));
            // AddFunction(typeof(FaceToTarget));
            // AddFunction(typeof(DashForward));

            AddFunction(typeof(Reposition_Spheres_Front));
            AddFunction(typeof(Reposition_Spheres_Back));
            AddFunction(typeof(Reposition_Spheres_Left));
            AddFunction(typeof(Reposition_Spheres_Right));
            AddFunction(typeof(Reposition_Spheres_Bottom));

            AddFunction(typeof(CheckFrontBlocking));
            AddFunction(typeof(CheckBackBlocking));
            AddFunction(typeof(CheckRightBlocking));
            AddFunction(typeof(CheckLeftBlocking));

            // AddFunction(typeof(SetTransform));

            AddFunction(typeof(Look));

            AddFunction(typeof(ShotDirection));

            AddGlobalFunction(typeof(TestGlobalFunction));
        }

        void AddFunction(System.Type type) {
            if (type.IsSubclassOf(typeof(PlayerFunction))) {
                GameObject obj = new GameObject();
                obj.transform.parent = this.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                
                PlayerFunction f = obj.AddComponent(type) as PlayerFunction;
                DicFunctions.Add(type, f);

                f.PlayerControl = GetComponentInParent<PlayerControl>();                 

                obj.name = type.ToString();
                obj.name = obj.name;                
            }
        }

        void AddGlobalFunction(System.Type type) {
            if (type.IsSubclassOf(typeof(CharacterBaseFunction<ICharacterControl>))) {
                GameObject obj = new GameObject();
                obj.transform.parent = this.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                
                CharacterBaseFunction<ICharacterControl> f = obj.AddComponent(type) as CharacterBaseFunction<ICharacterControl>;
                DicGlobalFunctions.Add(type, f);

                f.CharacterControl = GetComponentInParent<PlayerControl>();

                obj.name = type.ToString();
                obj.name = obj.name;                
            }
        }
    }    
}