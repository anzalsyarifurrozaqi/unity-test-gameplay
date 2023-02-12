using System.Collections.Generic;
using Player;
using Enum;
using Character.Base;

public class IndexChecker {
    public static bool MakeTransition(ICharacterControl control, List<TransitionConditionType> transitionConditions) {
        foreach (TransitionConditionType c in transitionConditions) {
            CheckConditionBase check = GetConditionChecker.GET(c);

            if (!check.MeetCondition(control)) {
                return false;
            }
        }

        return true;
    }

    public static bool NotCondition(ICharacterControl control, List<TransitionConditionType> transitionConditions) {
        foreach (TransitionConditionType c in transitionConditions) {
            CheckConditionBase check = GetConditionChecker.GET(c);

            if (check.MeetCondition(control)) {
                return true;
            }
        }
        
        return false;
    }
}
