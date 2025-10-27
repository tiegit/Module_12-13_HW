using UnityEngine;

namespace ExtraGame
{
    public class DirectionalRotator
    {
        private PlayerInput _playerInput;
        private Rigidbody _rigidbody;
        private Transform _rotationCenterTransform;
        private float _rotationSpeed;

        public DirectionalRotator(PlayerInput playerInput,
                                  Rigidbody rigidbody,
                                  Transform targetTransform,
                                  float rotationSpeed)
        {
            _playerInput = playerInput;
            _rigidbody = rigidbody;
            _rotationCenterTransform = targetTransform;
            _rotationSpeed = rotationSpeed;
        }

        public void CustomFixedUpdate()
        {
            if (_playerInput == null || _playerInput.HorizontalInput == 0 && _playerInput.VerticalInput == 0 || _rotationCenterTransform == null)
                return;

            _rigidbody.AddTorque(-_rotationCenterTransform.forward * _playerInput.HorizontalInput * _rotationSpeed, ForceMode.Acceleration);

            _rigidbody.AddTorque(_rotationCenterTransform.right * _playerInput.VerticalInput * _rotationSpeed, ForceMode.Acceleration);
        }
    }
}