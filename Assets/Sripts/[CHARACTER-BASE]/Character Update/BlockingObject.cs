using Character.Base.Function;

namespace Character.Base.Update {
    public class BlockingObject : CharacterBaseUpdate<ICharacterControl> {
        public override void OnFixedUpdate() {
            CharacterControl.RunGlobalFunction(typeof(CheckFrontBlocking), 0.25f);
            CharacterControl.RunGlobalFunction(typeof(CheckBackBlocking), 0.25f);
            CharacterControl.RunGlobalFunction(typeof(CheckLeftBlocking), 0.25f);
            CharacterControl.RunGlobalFunction(typeof(CheckRightBlocking), 0.25f);

            // debug
            // if (PlayerControl.DATASET.BLOCKING_DATA.FrontBlockingObjects != null) {
            //     foreach (KeyValuePair<GameObject, List<GameObject>> dicFrontBlockingObject in PlayerControl.DATASET.BLOCKING_DATA.FrontBlockingObjects) {
            //         Debug.Log(dicFrontBlockingObject.Value.Count);
            //     }
            // }
        }
    }
}
