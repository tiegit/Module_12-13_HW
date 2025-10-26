using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(CharacterInteraction)))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    //[SerializeField] private float _maxAngularVelocity = 5f;

    private DirectionalRotator _rotator;

    private Rigidbody _rigidbody;
    
    public Vector3 CurrentVelocity => _rigidbody.velocity;
    public Vector3 CurrentRotation => _rigidbody.angularVelocity;

    public void Initialize(PlayerInput playerInput, TargetFollower cameraBase)
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.maxAngularVelocity = _maxAngularVelocity;

        _rotator = new DirectionalRotator(_rigidbody, playerInput, cameraBase, _rotationSpeed);
    }

    private void FixedUpdate() => _rotator.CustomFixedUpdate();
}
