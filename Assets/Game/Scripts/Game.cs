using UnityEngine;

public class Game : MonoBehaviour
{
    private Character _character;
    private PlayerInput _playerInput;
    private ScoreCounter _scoreCounter;

    public void Initialize(Character character, PlayerInput playerInput, ScoreCounter scoreCounter)
    {
        _character = character;
        _playerInput = playerInput;
        _scoreCounter = scoreCounter;
    }

    private void Update()
    {
        _playerInput.CustomUpdate();
    }
}
