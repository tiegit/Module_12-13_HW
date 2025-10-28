using UnityEngine;

namespace ExtraGame
{
    [RequireComponent(typeof(Rigidbody), (typeof(GroundInteraction)))]

    public class Ground : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxGroundAngleDegrees = 45f;

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

            float minGroundDotProduct = Mathf.Cos(_maxGroundAngleDegrees * Mathf.Deg2Rad);
            _groundInteraction.Initialize(minGroundDotProduct);

            _rotator = new DirectionalRotator(playerInput, _rigidbody, _rotationSpeed);
        }

        private void FixedUpdate()
        {
            if (_isPaused)
                return;

            _groundContactPoint.transform.position = _groundInteraction.ContactPoint;
            _rigidbody.centerOfMass = transform.InverseTransformPoint(_groundContactPoint.position); // если убрать эту штуку, то вращение будет от центра платформы

            _rotator.CustomFixedUpdate(_groundContactPoint);
        }

        public void SetPauseToggle(bool isPause) => _isPaused = isPause;

        public void ResetGround()
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