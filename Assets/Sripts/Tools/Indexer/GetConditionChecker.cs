using System.Collections.Generic;
using UnityEngine;
using Enum;

public class GetConditionChecker : MonoBehaviour {
    static Dictionary<TransitionConditionType, CheckConditionBase> DicCheckers;
    static GameObject ConditionParent = null;

    public static CheckConditionBase GET(TransitionConditionType conditionType) {
        if (DicCheckers == null) {
            InitDic();
        }

        return DicCheckers[conditionType];
    }

    public static void InitDic() {
        DicCheckers = new Dictionary<TransitionConditionType, CheckConditionBase>();
        
        _Add(TransitionConditionType.MOVING, typeof(CheckCondition_Moving));
        _Add(TransitionConditionType.ATTACKING, typeof(CheckCondition_Attacking));
        _Add(TransitionConditionType.FACING_TO_TARGET, typeof(CheckCondition_FacingToTarget));
        _Add(TransitionConditionType.DASH, typeof(CheckCondition_Dash));
        _Add(TransitionConditionType.TURN, typeof(CheckCondition_BackTurn));
    }

    static void _Add(TransitionConditionType transitionConditionType, System.Type checkConditionType) {
        if (ConditionParent == null) {
            ConditionParent = new GameObject();
            ConditionParent.name = "Condition Checker";
            ConditionParent.transform.position = Vector3.zero;
            ConditionParent.transform.rotation = Quaternion.identity;
        }

        if (checkConditionType.IsSubclassOf(typeof(CheckConditionBase))) {
            GameObject obj = new GameObject();
            obj.transform.parent = ConditionParent.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.name = checkConditionType.ToString();

            CheckConditionBase condition = obj.AddComponent(checkConditionType) as CheckConditionBase;

            DicCheckers.Add(transitionConditionType, condition);
        }
    }
}
