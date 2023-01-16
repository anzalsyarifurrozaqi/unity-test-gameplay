using UnityEngine;
using Player;

public abstract class CheckConditionBase : MonoBehaviour {
    public abstract bool MeetCondition(PlayerControl control);
}
