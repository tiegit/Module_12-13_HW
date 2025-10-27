using UnityEngine;

namespace ExtraGame
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Ground _ground;

        [SerializeField, Space(10)] private TargetFollower _cameraBase;

        [SerializeField, Space(10)] private Game _game;
        [SerializeField] private float _gameDurationInSeconds = 60;

        [SerializeField, Space(10)] private Coins _coins;

        private PlayerInput _playerInput;

        private ObjectRotator _cameraObjectRotator;

        private ScoreCounter _scoreCounter;
        private CoinsContainer _coinsContainer;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _scoreCounter = new ScoreCounter();
            _coinsContainer = new CoinsContainer(_coins.CoinsList);

            _cameraObjectRotator = _cameraBase.GetComponent<ObjectRotator>();
            _cameraObjectRotator.Initialize(_playerInput);

            _character.Initialize(_playerInput, _scoreCounter, _coinsContainer, _cameraBase);

            _ground.Initialize(_playerInput);

            _game = new Game(_playerInput, _character, _ground, _coinsContainer, _scoreCounter, _gameDurationInSeconds);
        }

        private void Update()
        {
            _playerInput.CustomUpdate();
            _game.CustomUpdate(Time.deltaTime);
        }
    }
}