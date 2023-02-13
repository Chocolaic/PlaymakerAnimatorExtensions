using HutongGames.PlayMaker;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateSync : StateMachineBehaviour
{
    [SerializeField] string m_targetFsmName;

    private PlayMakerFSM _targetFsm;

    private Dictionary<int, FsmState> _stateDic = new Dictionary<int, FsmState>();
    public void FromAnimator(Animator animator)
    {
        var fsms = animator.GetComponents<PlayMakerFSM>();
        foreach (var e in fsms)
        {
            if (e.FsmName.Equals(m_targetFsmName))
            {
                _targetFsm = e;
                break;
            }
        }
        foreach (var e in _targetFsm.FsmStates)
        {
            int hashId = Animator.StringToHash(e.Name);
            _stateDic[hashId] = e;
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_stateDic.TryGetValue(stateInfo.shortNameHash, out var state)) return;

        _targetFsm.Fsm.SwitchState(state);
    }
}
