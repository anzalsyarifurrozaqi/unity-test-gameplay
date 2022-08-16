using UnityEngine;
using Character;
using Character.Function;

public class RootMotionHandler : MonoBehaviour {
    [SerializeField] private CharacterControl _controller;
    private void Start() {
        _controller = GetComponentInParent<CharacterControl>();
    }
    private void OnAnimatorMove() {
        Animator animator = _controller.ANIMATOR;
        if (animator != null)
            _controller.RunFunction(typeof(SetTransform), animator.rootPosition, animator.rootRotation);
    }
}
