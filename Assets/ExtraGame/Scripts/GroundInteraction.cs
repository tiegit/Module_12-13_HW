using UnityEngine;

namespace ExtraGame
{
    public class GroundInteraction : MonoBehaviour
    {
        private float _minGroundDotProduct;

        public Vector3 ContactPoint { get; private set; } = Vector3.zero;

        public void Initialize(float minGroundDotProduct) => _minGroundDotProduct = minGroundDotProduct;

        private void OnCollisionEnter(Collision collision)
        {
            CollisionProcess(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            CollisionProcess(collision);
        }

        private void CollisionProcess(Collision collision)
        {
            Character character = collision.gameObject.GetComponent<Character>();

            if (character != null)
            {
                foreach (ContactPoint contact in collision.contacts)
                {
                    if (Vector3.Dot(contact.normal, Vector3.down) >= _minGroundDotProduct)
                    {
                        ContactPoint = contact.point;
                        break;
                    }
                }
            }
        }
    }
}
