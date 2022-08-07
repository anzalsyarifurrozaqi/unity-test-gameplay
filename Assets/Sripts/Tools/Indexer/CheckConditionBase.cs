using UnityEngine;
using Character;

public abstract class CheckConditionBase : MonoBehaviour {
    public abstract bool MeetCondition(CharacterControl control);
}
