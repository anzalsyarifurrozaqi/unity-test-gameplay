using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockingData {
    public Dictionary<GameObject, List<GameObject>> FrontBlockingObjects = new Dictionary<GameObject, List<GameObject>>();
    public Dictionary<GameObject, List<GameObject>> BackBlockingObjects = new Dictionary<GameObject, List<GameObject>>();
    public Dictionary<GameObject, List<GameObject>> LeftBlockingObjects = new Dictionary<GameObject, List<GameObject>>();
    public Dictionary<GameObject, List<GameObject>> RightBlockingObjects = new Dictionary<GameObject, List<GameObject>>();
    public Dictionary<GameObject, List<GameObject>> DownBlockingObjects = new Dictionary<GameObject, List<GameObject>>();
}
