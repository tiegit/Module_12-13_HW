using UnityEngine;

public class JumpHandler
{
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private float _jumpForce;
    private bool _jumpPressedLastFrame;

    public JumpHandler(PlayerInput playerInput, Rigidbody rigidbody, float jumpForce)
    {
        _playerInput = playerInput;
        _rigidbody = rigidbody;
        _jumpForce = jumpForce;
    }

    public void CustomFixedUpdate(bool isGrounded)
    {
        if (_playerInput.JumpPressed && !_jumpPressedLastFrame && isGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

        _jumpPressedLastFrame = _playerInput.JumpPressed;
    }
}
