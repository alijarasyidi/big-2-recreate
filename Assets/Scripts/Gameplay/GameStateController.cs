using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using VContainer.Unity;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class GameStateController : IAsyncStartable
    {
        private GameStateEnum _currentState = GameStateEnum.Preparing;

        private readonly ICardShuffleService _cardShuffleService;

        public GameStateController(ICardShuffleService cardShuffleService)
        {
            _cardShuffleService = cardShuffleService;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log("Game preparing...");

            // TODO remove later with starting visual impelemtation
            await UniTask.Delay(1000);

            Debug.Log("Game start...");
            await StartGameAsync(cancellationToken: default);
        }

        public async UniTask StartGameAsync(CancellationToken cancellationToken)
        {
            if (_currentState != GameStateEnum.Preparing)
            {
                throw new InvalidOperationException("Invalid StartGameAsync call!");
            }

            // TODO resolve game mode
            int playerCount = 4;

            var shuffleResult = _cardShuffleService.Shuffle(playerCount);
            var firstTurnPlayerIndex = _cardShuffleService.GetFirstTurnPlayerIndex(shuffleResult);

            Debug.LogFormat("First turn player index: {0}", firstTurnPlayerIndex);
        }
    }
}
