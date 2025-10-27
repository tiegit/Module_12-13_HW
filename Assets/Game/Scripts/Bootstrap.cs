using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private HeadPointer _headPointer;

    [SerializeField, Space(10)] private TargetFollower _cameraBase;

    [SerializeField, Space(10)] private Game _game;

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

        _character.Initialize(_playerInput, _headPointer, _scoreCounter, _coinsContainer, _cameraBase);

        _game = new Game(_character, _coinsContainer, _scoreCounter);
    }

    private void Update()
    {
        _playerInput.CustomUpdate();
        _game.CustomUpdate();
    }
}
