using UnityEngine;

internal class DirectionalRotator
{
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private readonly TargetFollower _targetFollower;
    private float _rotationSpeed;

    private Transform _targetCenter;

    public DirectionalRotator(PlayerInput playerInput,
                              Rigidbody rigidbody,
                              TargetFollower targetFollower,
                              float rotationSpeed)
    {
        _playerInput = playerInput;
        _rigidbody = rigidbody;
        _targetFollower = targetFollower;
        _rotationSpeed = rotationSpeed;

        _targetCenter = _targetFollower.transform;
    }

    public void CustomFixedUpdate()
    {
        if (_playerInput == null || _playerInput.HorizontalInput == 0 && _playerInput.VerticalInput == 0 || _targetCenter == null)
            return;
              
        _rigidbody.AddTorque(-_targetCenter.forward * _playerInput.HorizontalInput * _rotationSpeed);

        _rigidbody.AddTorque(_targetCenter.right * _playerInput.VerticalInput * _rotationSpeed);
    }
}