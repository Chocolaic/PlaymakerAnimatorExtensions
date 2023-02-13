using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorSyncBehaviour : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        var fsmStateMachines = _animator.GetBehaviours<FsmStateSync>();

        foreach (var sm in fsmStateMachines)
        {
            sm.FromAnimator(_animator);
        }
    }
}
