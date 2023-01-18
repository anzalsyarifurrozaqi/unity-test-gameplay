using UnityEngine;
using Character.Base;

public class CheckCondition_FacingToTarget : CheckConditionBase {
    public override bool MeetCondition(ICharacterControl control) {        
        RaycastHit hit;
        if (Physics.Raycast(control.transform.position, control.transform.forward, out hit, float.MaxValue, LayerMask.GetMask("Target"))) {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(control.transform.position, hit.transform.position, Color.red);
            return true;
        }
        return false;
    }
}
