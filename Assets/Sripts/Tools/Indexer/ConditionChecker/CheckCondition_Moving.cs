using Player;
using UnityEngine;

public class CheckCondition_Moving : CheckConditionBase
{
    public override bool MeetCondition(PlayerControl control) {
        if (control.Move != Vector2.zero) {
            return true;
        }

        return false;
    }
}
