using UnityEngine;

namespace ExtraGame
{
    public class HeadPointer
    {
        private Transform _headTransform;
        private Rigidbody _characterRigidbody;
        private float _rotationSpeed;

        public HeadPointer(Transform headTransform, Rigidbody characterRigidbody, float rotationSpeed)
        {
            _headTransform = headTransform;
            _characterRigidbody = characterRigidbody;
            _rotationSpeed = rotationSpeed;
        }

        public void CustomUpdate(float deltaTime)
        {
            if (_characterRigidbody != null)
            {
                Vector3 velocity = _characterRigidbody.velocity;

                if (velocity != Vector3.zero)
                {
                    Vector3 direction = new Vector3(velocity.x, 0, velocity.z).normalized;

                    Quaternion targetRotation = Quaternion.LookRotation(direction);

                    _headTransform.rotation = Quaternion.RotateTowards(_headTransform.rotation, targetRotation, _rotationSpeed * deltaTime);
                }
            }
        }
    }
}