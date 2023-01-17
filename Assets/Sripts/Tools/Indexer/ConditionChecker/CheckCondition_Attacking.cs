using System.Collections;
using Player;
using Character.Base;
public class CheckCondition_Attacking : CheckConditionBase {
    public override bool MeetCondition(ICharacterControl control) {
        // if (control.Attack) {
        //     return true;
        // }

        return false;
    }
}
