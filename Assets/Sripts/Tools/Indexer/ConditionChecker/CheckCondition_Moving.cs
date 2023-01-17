using Player;
using UnityEngine;
using Character.Base;

public class CheckCondition_Moving : CheckConditionBase
{
    public override bool MeetCondition(ICharacterControl control) {
        if (control.MOVE != Vector2.zero) {
            return true;
        }

        return false;
    }
}
