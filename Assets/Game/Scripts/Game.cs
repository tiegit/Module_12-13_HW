using UnityEngine;
using UnityEngine.TextCore.Text;

public class Game
{
    private Character _character;
    private CoinsContainer _coinsContainer;
    private ScoreCounter _scoreCounter;

    private float _stopGameDelay = 2f;
    private float _timer;
    public Game(Character character, CoinsContainer coinsContainer, ScoreCounter scoreCounter)
    {
        _character = character;
        _coinsContainer = coinsContainer;
        _scoreCounter = scoreCounter;
    }

    public bool IsPaused { get; private set; } = true;

    public void CustomUpdate()
    {
        if (_coinsContainer.GetCoinsCount() == 0)
        {
            StopGame();
        }
    }

    public void StartGame()
    {
        SetPause(false);
    }

    public void ResetGame()
    {
        _character.ResetCharacter();
        _coinsContainer.ResetCoinsContainer();
        _scoreCounter.ResetScore();

        SetPause(false);
    }

    private void StopGame()
    {
        SetPause(true);
    }

    private void SetPause(bool isPaused)
    {
        IsPaused = isPaused;
        _character.SetPauseToggle(IsPaused);

        if (IsPaused)
        {
            Debug.Log("Игра остановлена. Для рестарта нажмите Enter.");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResetGame();
            }
        }
    }
}
