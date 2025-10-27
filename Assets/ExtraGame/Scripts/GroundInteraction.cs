using System;
using UnityEngine;

namespace ExtraGame
{
    public class GroundInteraction : MonoBehaviour
    {
        public Vector3 ContactPoint { get; private set; } = Vector3.zero;


        private void OnCollisionEnter(Collision collision)
        {
            Character character = collision.gameObject.GetComponent<Character>();

            if (character != null)
            {
                ContactPoint = collision.contacts[0].point;
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            Character character = collision.gameObject.GetComponent<Character>();

            if (character != null)
            {
                ContactPoint = collision.contacts[0].point;
            }
        }
    }
}