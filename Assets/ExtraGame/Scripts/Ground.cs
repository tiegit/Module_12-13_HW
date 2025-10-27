using UnityEngine;

namespace ExtraGame
{
    [RequireComponent(typeof(Rigidbody), (typeof(GroundInteraction)))]

    public class Ground : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        [SerializeField] private Transform _groundContactPoint;

        private Rigidbody _rigidbody;
        private GroundInteraction _groundInteraction;

        private Vector3 _initialPosition;
        private Quaternion _initialRotation;

        private DirectionalRotator _rotator;

        private bool _isPaused;

        public void Initialize(PlayerInput playerInput)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundInteraction = GetComponent<GroundInteraction>();

            _initialPosition = transform.position;
            _initialRotation = transform.rotation;

            _rotator = new DirectionalRotator(playerInput, _rigidbody, _groundContactPoint, _rotationSpeed);
        }

        private void FixedUpdate()
        {
            if (_isPaused)
                return;

            _groundContactPoint.transform.position = _groundInteraction.ContactPoint;

            _rotator.CustomFixedUpdate();
        }

        public void SetPauseToggle(bool isPause) => _isPaused = isPause;

        public void ResetCharacter()
        {
            _rigidbody.gameObject.SetActive(false);

            _rigidbody.isKinematic = true;

            transform.position = _initialPosition;
            transform.rotation = _initialRotation;

            _rigidbody.isKinematic = false;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;

            _rigidbody.gameObject.SetActive(true);
        }
    }
}