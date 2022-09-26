using System.Collections.Generic;
using UnityEngine;
using Character.Update;
public class BlockingObject : CharacterUpdate {
    public override void OnFixedUpdate() {
        CharacterControl.RunFunction(typeof(CheckFrontBlocking), 0.25f);
        CharacterControl.RunFunction(typeof(CheckBackBlocking), 0.25f);
        CharacterControl.RunFunction(typeof(CheckLeftBlocking), 0.25f);
        CharacterControl.RunFunction(typeof(CheckRightBlocking), 0.25f);

        // debug
        // if (CharacterControl.DATASET.BLOCKING_DATA.FrontBlockingObjects != null) {
        //     foreach (KeyValuePair<GameObject, List<GameObject>> dicFrontBlockingObject in CharacterControl.DATASET.BLOCKING_DATA.FrontBlockingObjects) {
        //         Debug.Log(dicFrontBlockingObject.Value.Count);
        //     }
        // }
    }
}
