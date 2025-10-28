using UnityEngine;

namespace ExtraGame
{
    [RequireComponent(typeof(Rigidbody), (typeof(CharacterInteraction)))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform _headTransform;
        [SerializeField] private float _headRotationSpeed = 200f;
        [SerializeField] private float _dieLimitY = -30f;

        private Rigidbody _rigidbody;
        private CharacterInteraction _characterInteraction;
        private Transform _startPoint;
        private HeadPointer _headPointer;

        private bool _isPaused;

        public bool IsAlive { get; private set; } = true;

        public void Initialize(Transform startPoint,
                               PlayerInput playerInput,
                               ScoreCounter scoreCounter,
                               CoinsContainer coinsContainer,
                               TargetFollower cameraBase)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _characterInteraction = GetComponent<CharacterInteraction>();

            _startPoint = startPoint;

            ResetCharacter();

            _characterInteraction.Initialize(scoreCounter, coinsContainer);

            _headPointer = new HeadPointer(_headTransform, _rigidbody, _headRotationSpeed);
        }

        private void Update()
        {
            if (_isPaused)
                return;

            _headPointer.CustomUpdate(Time.deltaTime);

            if (transform.position.y < _startPoint.position.y + _dieLimitY)            
                IsAlive = false;            
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

            transform.position = _startPoint.position;
            transform.rotation = _startPoint.rotation;

            _rigidbody.isKinematic = false;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;

            _rigidbody.gameObject.SetActive(true);

            IsAlive = true;
        }
    }
}