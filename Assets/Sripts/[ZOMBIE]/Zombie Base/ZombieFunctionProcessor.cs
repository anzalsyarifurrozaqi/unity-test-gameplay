using System.Collections.Generic;
using UnityEngine;
using Character.Base;
using Character.Base.Function;

namespace Zombie.Function {
    public class ZombieFunctionProcessor : MonoBehaviour {
    public Dictionary<System.Type, ZombieFunction> DicFunctions = new Dictionary<System.Type, ZombieFunction>();
        public Dictionary<System.Type, CharacterBaseFunction<ICharacterControl>> DicGlobalFunctions = new Dictionary<System.Type, CharacterBaseFunction<ICharacterControl>>();

        private void Start()
        {            
            Debug.Log("Loading Default Player Function: " + GetComponentInParent<ZombieControl>().name);
            SetDeafaultFunction();

            ZombieControl control = GetComponentInParent<ZombieControl>();
            control.InitializeCharacter();
        }

        void SetDeafaultFunction()
        {
            AddFunction(                                    typeof(InitZombie));            
             
            AddGlobalFunction(                              typeof(TestGlobalFunction));            

            AddGlobalFunction(                              typeof(CheckFrontBlocking));
            AddGlobalFunction(                              typeof(CheckBackBlocking));
            AddGlobalFunction(                              typeof(CheckRightBlocking));
            AddGlobalFunction(                              typeof(CheckLeftBlocking));
            AddGlobalFunction(                              typeof(Reposition_Spheres_Front));
            AddGlobalFunction(                              typeof(Reposition_Spheres_Back));
            AddGlobalFunction(                              typeof(Reposition_Spheres_Left));
            AddGlobalFunction(                              typeof(Reposition_Spheres_Right));
            AddGlobalFunction(                              typeof(Reposition_Spheres_Bottom));
        }

        void AddFunction(System.Type type) {
            if (type.IsSubclassOf(typeof(ZombieFunction))) {
                GameObject obj = new GameObject();
                obj.transform.parent = this.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                
                ZombieFunction f = obj.AddComponent(type) as ZombieFunction;
                DicFunctions.Add(type, f);

                f.ZombieControl = GetComponentInParent<ZombieControl>();                 

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

                f.CharacterControl = GetComponentInParent<ZombieControl>();

                obj.name = type.ToString();
                obj.name = obj.name;                
            }
        }
    }
}
