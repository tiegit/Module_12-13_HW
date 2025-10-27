using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(CharacterInteraction)))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _maxGroundAngleDegrees = 45f;

    private Rigidbody _rigidbody;
    private CharacterInteraction _characterInteraction;

    private DirectionalRotator _rotator;
    private JumpHandler _jumpHandler;

    public Vector3 CurrentVelocity => _rigidbody.velocity;
    public Vector3 CurrentRotation => _rigidbody.angularVelocity;

    public void Initialize(PlayerInput playerInput, TargetFollower cameraBase)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterInteraction = GetComponent<CharacterInteraction>();

        float minGroundDotProduct = Mathf.Cos(_maxGroundAngleDegrees * Mathf.Deg2Rad);
        _characterInteraction.Initialize(minGroundDotProduct);

        _rotator = new DirectionalRotator(playerInput, _rigidbody, cameraBase, _rotationSpeed);
        _jumpHandler = new JumpHandler(playerInput, _rigidbody, _jumpForce);
    }

    private void FixedUpdate()
    {
        _rotator.CustomFixedUpdate();
        _jumpHandler.CustomFixedUpdate(_characterInteraction.IsGrounded);

        if (_characterInteraction.IsGrounded)
        {
            _characterInteraction.ResetGroundFlag();
        }
    }
}
