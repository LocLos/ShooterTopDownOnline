using Mirror;
using UnityEngine;

namespace ShooterTopDown
{
    public class PlayerAnimator : NetworkBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetTrigger(string triggerName)
        {
            _animator.SetTrigger(triggerName);
        }

        public void SetBool(string triggerName, bool isActive)
        {
            _animator.SetBool(triggerName, isActive);
        }
    }
}