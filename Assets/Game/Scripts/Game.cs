using UnityEngine;

public class Game : MonoBehaviour
{
    private PlayerInput _playerInput;
    private CharacterInteraction _characterInteraction;
    private ScoreCounter _scoreCounter;

    public void Initialize(PlayerInput playerInput, CharacterInteraction characterInteraction, ScoreCounter scoreCounter)
    {
        _playerInput = playerInput;
        _characterInteraction = characterInteraction;
        _scoreCounter = scoreCounter;
    }

    private void Update()
    {
        _playerInput.CustomUpdate();
    }
}
