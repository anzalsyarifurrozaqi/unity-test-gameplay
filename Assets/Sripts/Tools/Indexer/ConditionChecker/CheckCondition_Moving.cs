using Character;
using UnityEngine;

public class CheckCondition_Moving : CheckConditionBase
{
    public override bool MeetCondition(CharacterControl control) {
        if (control.Move != Vector2.zero) {
            return true;
        }

        return false;
    }
}
