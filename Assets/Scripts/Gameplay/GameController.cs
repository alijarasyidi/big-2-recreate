using Alija.Big2.Client.Screen;
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
        private readonly ITableController _tableController;
        private readonly ITableView _tableView;
        private readonly IParticipantView _participantView;

        public GameController(
            ParticipantResolver participantResolver,
            ICardShuffleService cardShuffleService,
            ITableController tableController,
            ITableView tableView,
            IParticipantView participantView)
        {
            _participantResolver = participantResolver;
            _cardShuffleService = cardShuffleService;
            _tableController = tableController;
            _tableView = tableView;
            _participantView = participantView;
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

            List<IParticipantInfo> participantInfos = new();
            _participantHasMap.Clear();
            foreach (var participant in participants)
            {
                participantInfos.Add(participant);
                _participantHasMap.Add(participant.Id, participant);
            }

            _tableController.Setup(participantInfos);
            _participantView.Setup(participantInfos);

            // TODO provide proper cancellation token
            await _tableView.DoShuffleVisualAsync(shuffleResult, cancellationToken: default);

            var firstPlayerId = participants[firstTurnPlayerIndex].Id;
            _participantView.StartTurn(firstPlayerId);
            _participantHasMap[firstPlayerId].StartTurnAsync(
                NextTurn,
                cancellationToken: default).Forget();
        }

        private void NextTurn(
            ParticipantIdEnum currentParticipantId,
            ISubmittableCard submittedCard)
        {
            Debug.LogFormat("{0} submitted:", currentParticipantId);
            if (submittedCard.Cards != null)
            {
                foreach (var card in submittedCard.Cards)
                {
                    Debug.LogFormat("{0} {1}", card.Rank, card.Suite);
                }
            }
            Debug.LogFormat(
                "card left: {0}",
                _participantHasMap[currentParticipantId].CardCount);

            _tableController.SubmitCard(currentParticipantId, submittedCard);

            if (_participantHasMap[currentParticipantId].CardCount <= 0)
            {
                // TODO handle game finish
                Debug.LogFormat("Game finished. Winner: {0}", _participantHasMap[currentParticipantId].Name);
                _currentState = GameStateEnum.Ended;
            }
            else
            {
                var nextParticipantId = _participantHasMap[currentParticipantId].NextId;
                _participantView.StartTurn(nextParticipantId);
                _participantHasMap[nextParticipantId].StartTurnAsync(
                    NextTurn,
                    cancellationToken: default).Forget();
            }
        }
    }
}
