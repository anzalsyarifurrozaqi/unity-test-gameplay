using UnityEngine;
using System.Collections.Generic;

namespace Character.Query
{
    public class CharacterQueryProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, CharacterQuery> DicQueries = new Dictionary<System.Type, CharacterQuery>();        

        private void Awake()
        {
             Debug.Log("Loading Default Character Queries: " + GetComponentInParent<CharacterControl>().name);
            SetDefaultQueries();
        }

        void SetDefaultQueries()
        {        
        }

        void AddQuery(System.Type type)
        {
            if (type.IsSubclassOf(typeof(CharacterQuery)))
            {
                GameObject newQ = new GameObject();
                newQ.transform.parent = this.transform;
                newQ.transform.localPosition = Vector3.zero;
                newQ.transform.localRotation = Quaternion.identity;

                CharacterQuery q = newQ.AddComponent(type) as CharacterQuery;
                DicQueries.Add(type, q);

                q.CharacterControl = GetComponentInParent<CharacterControl>();

                newQ.name = type.ToString();
                newQ.name = newQ.name;                
            }
        }
    }
}