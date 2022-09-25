using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorForward : MonoBehaviour {
    [SerializeField] private Animator _anim;
    void Awake() {
        _anim = GetComponent<Animator>();
    }

    void OnAnimatorMove() {
        transform.parent.position = _anim.targetPosition;
        transform.parent.rotation = _anim.targetRotation;
    }
}
