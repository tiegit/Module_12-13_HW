using UnityEngine;

namespace ExtraGame
{
    public class CharacterInteraction : MonoBehaviour
    {       
        private CoinsContainer _coinsContainer;
        private ScoreCounter _scoreCounter;

        public void Initialize(ScoreCounter scoreCounter, CoinsContainer coinsContainer)
        {
            _coinsContainer = coinsContainer;
            _scoreCounter = scoreCounter;
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
    }
}