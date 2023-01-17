using Player;
using UnityEngine;
using Character.Base;

public class CheckCondition_BackTurn : CheckConditionBase {
    public override bool MeetCondition(ICharacterControl control) {

        // var forward = control.transform.forward;
        // var backward = -control.transform.forward;

        // Debug.Log($"{forward},{backward}");
        // var angle = Mathf.Atan2(control.Move.x, control.Move.y) * Mathf.Rad2Deg;
        // var targetRotation = Quaternion.Euler(0.0f, angle, 0.0f);

        // var rotation = control.transform.rotation.y - targetRotation.y;
        
        // if (rotation <= -1) return true;

        return false;
    }
}

// TODO : simpan last position