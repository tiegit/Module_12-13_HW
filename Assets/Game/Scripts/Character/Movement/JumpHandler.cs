using UnityEngine;

public class JumpHandler
{
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private float _jumpForce;

    public JumpHandler(PlayerInput playerInput, Rigidbody rigidbody, float jumpForce)
    {
        _playerInput = playerInput;
        _rigidbody = rigidbody;
        _jumpForce = jumpForce;
    }

    public void CustomFixedUpdate(bool isGrounded)
    {
        if (_playerInput.JumpPressed && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
