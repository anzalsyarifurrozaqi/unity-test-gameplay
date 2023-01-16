using UnityEngine;
using System.Collections.Generic;

namespace Player.Query
{
    public class PlayerQueryProcessor : MonoBehaviour
    {
        public Dictionary<System.Type, PlayerQuery> DicQueries = new Dictionary<System.Type, PlayerQuery>();        

        private void Awake()
        {
             Debug.Log("Loading Default Player Queries: " + GetComponentInParent<PlayerControl>().name);
            SetDefaultQueries();
        }

        void SetDefaultQueries()
        {        
        }

        void AddQuery(System.Type type)
        {
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
    }
}