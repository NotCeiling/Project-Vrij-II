using UnityEngine;

public class CharacterWalk : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speedThreshold = 0.1f;

    private void OnValidate()
    {
        if (_controller == null)
        {
            Debug.LogWarning("CharacterController is not assigned", this);
        }
        if (_animator == null)
        {
            Debug.LogWarning("Animator is not assigned", this);
        }
    }

    private void Update()
    {
        if (_controller == null || _animator == null) return;
        
        var isWalking = _controller.velocity.sqrMagnitude > _speedThreshold;
        _animator.SetBool(IsWalking, isWalking);
    }
}
