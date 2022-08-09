using System.Collections.Generic;
using UnityEngine;

public static class AddObjectToDictionary {
    public static void Add(Dictionary<GameObject, List<GameObject>> dic, GameObject key, GameObject value) {

        if (dic.ContainsKey(key)) {
            if (dic[key].Contains(value)) return;
            
            dic[key].Add(value);
        } else {
            dic.Add(key, new List<GameObject>());
            dic[key].Add(value);
        }
    }
}
