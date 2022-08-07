using Character;

public class CheckCondition_Dash : CheckConditionBase {
    public override bool MeetCondition(CharacterControl control) {
        if (control.Dash) {
            return true;
        }

        return false;
    }
}
