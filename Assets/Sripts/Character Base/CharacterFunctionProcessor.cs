using UnityEngine;
using System.Collections.Generic;

namespace Character.Function
{
    public class CharacterFunctionProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, CharacterFunction> DicFunctions = new Dictionary<System.Type, CharacterFunction>();        

        private void Start()
        {            
            Debug.Log("Loading Default Character Function: " + GetComponentInParent<CharacterControl>().name);
            SetDeafaultFunction();

            CharacterControl control = GetComponentInParent<CharacterControl>();
            control.InitalizeCharacter();
        }

        void SetDeafaultFunction()
        {
            AddFunction(typeof(InitCharacter));
            AddFunction(typeof(CalculateDirection));
            AddFunction(typeof(MoveForward));
            AddFunction(typeof(FaceToTarget));
            AddFunction(typeof(DashForward));
        }

        void AddFunction(System.Type type)
        {
            if (type.IsSubclassOf(typeof(CharacterFunction)))
            {
                GameObject obj = new GameObject();
                obj.transform.parent = this.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                
                CharacterFunction f = obj.AddComponent(type) as CharacterFunction;
                DicFunctions.Add(type, f);

                f.CharacterControl = GetComponentInParent<CharacterControl>();

                obj.name = type.ToString();
                obj.name = obj.name;                
            }
        }
    }    
}