using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private float _minGroundDotProduct;
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    public void Initialize(float minGroundDotProduct)
    {
        _minGroundDotProduct = minGroundDotProduct;
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) >= _minGroundDotProduct)
            {
                _isGrounded = true;
                break;
            }
        }
    }

    public void ResetGroundFlag()
    {
        _isGrounded = false;
    }
}