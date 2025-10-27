using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 15f;

    private PlayerInput _playerInput;

    public void Initialize(PlayerInput playerInput) => _playerInput = playerInput;

    private void Update()
    {
        if (_playerInput.MouseXInput == 0)
            return;

        float aroundXRotation = -_playerInput.MouseXInput * _sensitivity;

        transform.Rotate(Vector3.up, -aroundXRotation);
    }
}
