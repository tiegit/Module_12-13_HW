using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private float _minGroundDotProduct;
    private CoinsContainer _coinsContainer;
    private ScoreCounter _scoreCounter;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    public void Initialize(float minGroundDotProduct, ScoreCounter scoreCounter, CoinsContainer coinsContainer)
    {
        _minGroundDotProduct = minGroundDotProduct;
        _coinsContainer = coinsContainer;
        _scoreCounter = scoreCounter;
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

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            _scoreCounter.AddCoin(coin);
            _coinsContainer.RemoveCoin(coin);
        }
    }

    public void ResetGroundFlag() => _isGrounded = false;
}