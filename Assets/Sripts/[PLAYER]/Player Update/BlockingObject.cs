using System.Collections.Generic;
using UnityEngine;
using Player.Update;
public class BlockingObject : PlayerUpdate {
    public override void OnFixedUpdate() {
        PlayerControl.RunFunction(typeof(CheckFrontBlocking), 0.25f);
        PlayerControl.RunFunction(typeof(CheckBackBlocking), 0.25f);
        PlayerControl.RunFunction(typeof(CheckLeftBlocking), 0.25f);
        PlayerControl.RunFunction(typeof(CheckRightBlocking), 0.25f);

        // debug
        // if (PlayerControl.DATASET.BLOCKING_DATA.FrontBlockingObjects != null) {
        //     foreach (KeyValuePair<GameObject, List<GameObject>> dicFrontBlockingObject in PlayerControl.DATASET.BLOCKING_DATA.FrontBlockingObjects) {
        //         Debug.Log(dicFrontBlockingObject.Value.Count);
        //     }
        // }
    }
}
