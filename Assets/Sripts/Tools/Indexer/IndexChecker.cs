using System.Collections.Generic;
using Player;
using Enum;

public class IndexChecker {
    public static bool MakeTransition(PlayerControl control, List<TransitionConditionType> transitionConditions) {
        foreach (TransitionConditionType c in transitionConditions) {
            CheckConditionBase check = GetConditionChecker.GET(c);

            if (!check.MeetCondition(control)) {
                return false;
            }
        }

        return true;
    }

    public static bool NotCondition(PlayerControl control, List<TransitionConditionType> transitionConditions) {
        foreach (TransitionConditionType c in transitionConditions) {
            CheckConditionBase check = GetConditionChecker.GET(c);

            if (check.MeetCondition(control)) {
                return true;
            }
        }
        
        return false;
    }
}
