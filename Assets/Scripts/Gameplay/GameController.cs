using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using VContainer.Unity;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class GameController : IAsyncStartable
    {
        private GameStateEnum _currentState = GameStateEnum.Preparing;
        // TODO will need to properly implement game mode choose flow. Currently will only do PvCom4
        private GameModeEnum _gameMode = GameModeEnum.PvCom4;

        private readonly GameModeResolver _gameModeResolver;
        private readonly ICardShuffleService _cardShuffleService;

        public GameController(
            GameModeResolver gameModeResolver,
            ICardShuffleService cardShuffleService)
        {
            _gameModeResolver = gameModeResolver;
            _cardShuffleService = cardShuffleService;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log("Game preparing...");

            // TODO remove later with starting visual implementation
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

            _currentState = GameStateEnum.Started;

            var participants = _gameModeResolver.ResolveParticipants(_gameMode);

            var shuffleResult = _cardShuffleService.Shuffle(participants.Count);
            var firstTurnPlayerIndex = _cardShuffleService.GetFirstTurnPlayerIndex(shuffleResult);

            Debug.LogFormat("First turn player index: {0}", firstTurnPlayerIndex);
        }
    }
}
