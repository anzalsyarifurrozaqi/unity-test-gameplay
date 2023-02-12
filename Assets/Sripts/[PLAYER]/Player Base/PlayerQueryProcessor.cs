using UnityEngine;
using System.Collections.Generic;
using Character.Base;

namespace Player.Query {
    public class PlayerQueryProcessor : MonoBehaviour {
        public Dictionary<System.Type, PlayerQuery> DicQueries = new Dictionary<System.Type, PlayerQuery>(); 
        public Dictionary<System.Type, CharacterBaseQuery<ICharacterControl>> DicGlobalQueries = new Dictionary<System.Type, CharacterBaseQuery<ICharacterControl>>();        

        private void Awake() {
            Debug.Log("Loading Default Player Queries: " + GetComponentInParent<PlayerControl>().name);
            SetDefaultQueries();
        }

        void SetDefaultQueries() {        
            // add queries
        }

        void AddQuery(System.Type type) {
            if (type.IsSubclassOf(typeof(PlayerQuery)))
            {
                GameObject newQ = new GameObject();
                newQ.transform.parent = this.transform;
                newQ.transform.localPosition = Vector3.zero;
                newQ.transform.localRotation = Quaternion.identity;

                PlayerQuery q = newQ.AddComponent(type) as PlayerQuery;
                DicQueries.Add(type, q);

                q.PlayerControl = GetComponentInParent<PlayerControl>();

                newQ.name = type.ToString();
                newQ.name = newQ.name;                
            }
        }

        void AddGlobalQuery(System.Type type) {            
            if (type.IsSubclassOf(typeof(CharacterBaseQuery<ICharacterControl>)))
            {
                GameObject newQ = new GameObject();
                newQ.transform.parent = this.transform;
                newQ.transform.localPosition = Vector3.zero;
                newQ.transform.localRotation = Quaternion.identity;

                CharacterBaseQuery<ICharacterControl> q = newQ.AddComponent(type) as CharacterBaseQuery<ICharacterControl>;
                DicGlobalQueries.Add(type, q);

                q.CharacterControl = GetComponentInParent<PlayerControl>();

                newQ.name = type.ToString();
                newQ.name = newQ.name;                
            }            
        }
    }
}