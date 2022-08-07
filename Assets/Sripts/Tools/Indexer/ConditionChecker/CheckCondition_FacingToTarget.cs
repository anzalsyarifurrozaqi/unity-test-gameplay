using Character;
using UnityEngine;

public class CheckCondition_FacingToTarget : CheckConditionBase {
    public override bool MeetCondition(CharacterControl control) {        
        RaycastHit hit;
        if (Physics.Raycast(control.transform.position, control.transform.forward, out hit, float.MaxValue, LayerMask.GetMask("Target"))) {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(control.transform.position, hit.transform.position, Color.red);
            return true;
        }
        return false;
    }
}
