using UnityEngine;

namespace ExtraGame
{
    public class DirectionalRotator
    {
        private PlayerInput _playerInput;
        private Rigidbody _rigidbody;
        private float _rotationSpeed;

        public DirectionalRotator(PlayerInput playerInput,
                                  Rigidbody rigidbody,
                                  float rotationSpeed)
        {
            _playerInput = playerInput;
            _rigidbody = rigidbody;
            _rotationSpeed = rotationSpeed;
        }

        public void CustomFixedUpdate(Transform rotationCenterTransform)
        {
            if (_playerInput == null || _playerInput.HorizontalInput == 0 && _playerInput.VerticalInput == 0 || rotationCenterTransform == null)
                return;

            _rigidbody.AddTorque(-rotationCenterTransform.forward * _playerInput.HorizontalInput * _rotationSpeed, ForceMode.Acceleration);

            _rigidbody.AddTorque(rotationCenterTransform.right * _playerInput.VerticalInput * _rotationSpeed, ForceMode.Acceleration);
        }
    }
}