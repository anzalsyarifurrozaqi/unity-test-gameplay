using UnityEngine;
using Player;
using Character.Base;

public abstract class CheckConditionBase : MonoBehaviour {
    public abstract bool MeetCondition(ICharacterControl control);
}
