using Player;
using Character.Base;

public class CheckCondition_Dash : CheckConditionBase {
    public override bool MeetCondition(ICharacterControl control) {
        // if (control.Dash) {
        //     return true;
        // }

        return false;
    }
}
