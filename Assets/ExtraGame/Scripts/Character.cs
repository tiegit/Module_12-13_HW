using UnityEngine;

namespace ExtraGame
{
    [RequireComponent(typeof(Rigidbody), (typeof(CharacterInteraction)))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform _headTransform;
        [SerializeField] private float _headRotationSpeed = 200f;

        private Rigidbody _rigidbody;
        private CharacterInteraction _characterInteraction;

        private HeadPointer _headPointer;

        private Vector3 _initialPosition;
        private Quaternion _initialRotation;

        private bool _isPaused;

        public void Initialize(PlayerInput playerInput,
                               ScoreCounter scoreCounter,
                               CoinsContainer coinsContainer,
                               TargetFollower cameraBase)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _characterInteraction = GetComponent<CharacterInteraction>();

            _initialPosition = transform.position;
            _initialRotation = transform.rotation;

            _characterInteraction.Initialize(scoreCounter, coinsContainer);

            _headPointer = new HeadPointer(_headTransform, _rigidbody, _headRotationSpeed);
        }

        private void Update()
        {
            if (_isPaused)
                return;

            _headPointer.CustomUpdate(Time.deltaTime);
        }

        public void SetPauseToggle(bool isPause)
        {
            _isPaused = isPause;

            if (_isPaused)
                _rigidbody.isKinematic = true;
        }

        public void ResetCharacter()
        {
            _rigidbody.gameObject.SetActive(false);

            transform.position = _initialPosition;
            transform.rotation = _initialRotation;

            _rigidbody.isKinematic = false;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;

            _rigidbody.gameObject.SetActive(true);
        }
    }
}