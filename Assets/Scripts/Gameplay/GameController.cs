using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VContainer.Unity;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class GameController : IAsyncStartable
    {
        private GameStateEnum _currentState = GameStateEnum.Preparing;

        private Dictionary<ParticipantIdEnum, IParticipant> _participantHasMap = new();

        private readonly ParticipantResolver _participantResolver;
        private readonly ICardShuffleService _cardShuffleService;

        public GameController(
            ParticipantResolver participantResolver,
            ICardShuffleService cardShuffleService)
        {
            _participantResolver = participantResolver;
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

            // TODO implement game mode service to set and get game mode choosen
            var choosenGameMode = GameModeEnum.PvCom4;

            var participants = _participantResolver.ResolveParticipants(choosenGameMode);

            // TODO consider make ICardShuffleService.Shuffle also fully responsible for distribute the card to participants
            var shuffleResult = _cardShuffleService.Shuffle(participants.Count);
            var firstTurnPlayerIndex = _cardShuffleService.GetFirstTurnPlayerIndex(shuffleResult);
            for (int i = 0; i < participants.Count; i++)
            {
                participants[i].SetInitialCardInHandIndex(shuffleResult[i]);
            }

            _participantHasMap.Clear();
            foreach (var participant in participants)
            {
                _participantHasMap.Add(participant.Id, participant);
            }

            _participantHasMap[participants[firstTurnPlayerIndex].Id].StartTurn(NextTurn);
        }

        private void NextTurn(ParticipantIdEnum currentParticipantId)
        {
            if (_participantHasMap[currentParticipantId].CardCount <= 0)
            {
                // TODO handle game finish
                _currentState = GameStateEnum.Ended;
            }
            else
            {
                var nextParticipantId = _participantHasMap[currentParticipantId].NextId;
                _participantHasMap[nextParticipantId].StartTurn(NextTurn);
            }
        }
    }
}
