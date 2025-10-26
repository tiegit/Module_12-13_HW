using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private HeadPointer _headPointer;

    [SerializeField, Space(10)] private TargetFollower _cameraBase;

    [SerializeField, Space(10)] private Game _game;

    [SerializeField, Space(10)] private Coins _coins;

    private PlayerInput _playerInput;
    private CharacterInteraction _characterInteraction;

    private ObjectRotator _cameraObjectRotator;

    private CoinsContainer _coinsContainer;
    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _coinsContainer = new CoinsContainer(_coins.CoinsList);
        _scoreCounter = new ScoreCounter();

        _characterInteraction = _character.GetComponent<CharacterInteraction>();

        _cameraObjectRotator = _cameraBase.GetComponent<ObjectRotator>();

        _cameraObjectRotator.Initialize(_playerInput);

        _character.Initialize(_playerInput, _cameraBase);

        _headPointer.Initialize(_coinsContainer);

        _game.Initialize(_playerInput, _characterInteraction, _scoreCounter);
    }
}
