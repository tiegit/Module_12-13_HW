using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(CharacterInteraction)))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _maxGroundAngleDegrees = 45f;

    private Rigidbody _rigidbody;
    private CharacterInteraction _characterInteraction;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private DirectionalRotator _rotator;
    private JumpHandler _jumpHandler;
    private bool _isPaused;
    public Vector3 CurrentVelocity => _rigidbody.velocity;
    public Vector3 CurrentRotation => _rigidbody.angularVelocity;

    public void Initialize(PlayerInput playerInput,
                           HeadPointer headPointer,
                           ScoreCounter scoreCounter,
                           CoinsContainer coinsContainer,
                           TargetFollower cameraBase)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterInteraction = GetComponent<CharacterInteraction>();

        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        float minGroundDotProduct = Mathf.Cos(_maxGroundAngleDegrees * Mathf.Deg2Rad);
        _characterInteraction.Initialize(minGroundDotProduct, scoreCounter, coinsContainer);

        headPointer.Initialize(coinsContainer);

        _rotator = new DirectionalRotator(playerInput, _rigidbody, cameraBase, _rotationSpeed);
        _jumpHandler = new JumpHandler(playerInput, _rigidbody, _jumpForce);
    }

    private void FixedUpdate()
    {
        if (_isPaused)
            return;

        _rotator.CustomFixedUpdate();
        _jumpHandler.CustomFixedUpdate(_characterInteraction.IsGrounded);

        if (_characterInteraction.IsGrounded)
        {
            _characterInteraction.ResetGroundFlag();
        }
    }

    public void SetPauseToggle(bool isPause)
    {
        _isPaused = isPause;
    }

    public void ResetCharacter()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
