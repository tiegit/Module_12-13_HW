using UnityEngine;

internal class DirectionalRotator
{
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private readonly TargetFollower _targetFollower;
    private float _rotationSpeed;

    private Transform _targetCenter;

    public DirectionalRotator(Rigidbody rigidbody, PlayerInput playerInput, TargetFollower targetFollower, float rotationSpeed)
    {
        _rigidbody = rigidbody;
        _playerInput = playerInput;
        _targetFollower = targetFollower;
        _rotationSpeed = rotationSpeed;

        _targetCenter = _targetFollower.transform;
    }

    public Quaternion CurrentRotation { get; private set; }

    public void CustomFixedUpdate()
    {
        if (_playerInput == null || _playerInput.HorizontalInput == 0 && _playerInput.VerticalInput == 0 || _targetCenter == null)
            return;
              
        _rigidbody.AddTorque(-_targetCenter.forward * _playerInput.HorizontalInput * _rotationSpeed);

        _rigidbody.AddTorque(_targetCenter.right * _playerInput.VerticalInput * _rotationSpeed);
    }
}