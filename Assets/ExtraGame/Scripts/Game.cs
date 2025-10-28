using System;
using UnityEngine;

namespace ExtraGame
{
    public class Game
    {
        private const string WinMessage = "<color=orange>Победа!</color>";
        private const string LoseMessage = "<color=red>Проигрыш! Время вышло.</color>";
        private const string ContinueMessage = "<color=green>Игра остановлена. Нажмите Enter для продолжения игры.</color>";

        private PlayerInput _playerInput;
        private Character _character;
        private Ground _ground;
        private CoinsContainer _coinsContainer;
        private ScoreCounter _scoreCounter;
        private float _gameDuration = 5f;

        private float _timer;
        private float _lastLogTime;

        public Game(PlayerInput playerInput,
                    Character character,
                    Ground ground,
                    CoinsContainer coinsContainer,
                    ScoreCounter scoreCounter,
                    float gameDuration)
        {
            _playerInput = playerInput;
            _character = character;
            _ground = ground;
            _coinsContainer = coinsContainer;
            _scoreCounter = scoreCounter;
            _gameDuration = gameDuration;

            StartGame();
        }

        public bool IsPaused { get; private set; } = true;

        public void CustomUpdate(float deltaTime)
        {
            if (IsPaused && _playerInput.RestartPressed)
                RestartGame();

            if (IsPaused)
                return;

            _timer += deltaTime;
            _lastLogTime += deltaTime;

            float remainingTime = Mathf.Max(0f, _gameDuration - _timer);

            if (_lastLogTime >= 1f)
            {
                Debug.Log($"<color=yellow>Осталось : {remainingTime.ToString("F0")} сек.</color>");
                _lastLogTime = 0f;
            }

            CheckCharacterAlive();

            CheckWin();
        }

        private void StartGame() => SetPause(false);

        private void StopGame()
        {
            SetPause(true);

            Debug.Log(ContinueMessage);
        }

        private void RestartGame()
        {
            _character.ResetCharacter();
            _ground.ResetGround();
            _coinsContainer.ResetCoinsContainer();
            _scoreCounter.ResetScore();

            _timer = 0f;
            _lastLogTime = 0f;

            SetPause(false);
        }

        private void SetPause(bool isPaused)
        {
            IsPaused = isPaused;

            _character.SetPauseToggle(IsPaused);
            _ground.SetPauseToggle(IsPaused);
        }

        private void CheckCharacterAlive()
        {
            if (_character.IsAlive == false)
                StopGame();
        }

        private void CheckWin()
        {
            if (_coinsContainer.GetCoinsCount() == 0)
            {
                if (_timer <= _gameDuration)
                    Debug.Log(WinMessage);
                else
                    Debug.Log(LoseMessage);

                StopGame();
            }
        }
    }
}