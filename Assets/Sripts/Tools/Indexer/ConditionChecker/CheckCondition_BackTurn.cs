using Character;
using UnityEngine;

public class CheckCondition_BackTurn : CheckConditionBase {
    public override bool MeetCondition(CharacterControl control) {
        var angle = Mathf.Atan2(control.Move.x, control.Move.y) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.Euler(0.0f, angle, 0.0f);

        var rotation = control.transform.rotation.y - targetRotation.y;
        
        Debug.Log(rotation);
        if (rotation <= -1) return true;

        return false;
    }
}
