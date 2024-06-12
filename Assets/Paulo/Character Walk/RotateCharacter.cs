using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RotateCharacter : MonoBehaviour
{
    [SerializeField] private Transform _toRotate;
    
    private CharacterController _controller;
    private CharacterController Controller => _controller ? _controller : _controller = GetComponent<CharacterController>();
    
    private void Update()
    {
        if (_toRotate == null) return;
        
        // Rotate the character to the direction it is moving, in the Y axis, only if it is moving
        if (Controller.velocity.sqrMagnitude > 0.1f)
        {
            var direction = Controller.velocity.normalized;
            var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            _toRotate.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
