using Alija.Big2.Client.Gameplay;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;

#nullable enable

namespace Alija.Big2.Client.Screen
{
    public class TableView : ITableView
    {
        private readonly ICardCollection _cardCollection;
        private readonly CardPanelCollectionView _cardPanelCollectionView;

        public TableView(
            ICardCollection cardCollection,
            CardPanelCollectionView cardPanelCollectionView)
        {
            _cardCollection = cardCollection;
            _cardPanelCollectionView = cardPanelCollectionView;
        }

        public async UniTask DoShuffleVisualAsync(
            Dictionary<int, List<int>> shuffleResult,
            CancellationToken cancellationToken)
        {
            foreach (var participantShuffleResult in shuffleResult)
            {
                var cardPanelView = GetCardPanelView(
                    participantShuffleResult.Key,
                    shuffleResult.Keys.Count);
                for (int i = 0; i < participantShuffleResult.Value.Count; i++)
                {
                    if (participantShuffleResult.Key == 0)
                    {
                        cardPanelView.CardViews[i].sprite = _cardCollection.Cards[participantShuffleResult.Value[i]].CardView.Sprite;
                        cardPanelView.CardViews[i].gameObject.SetActive(true);
                        // TODO make this visual config
                        await UniTask.Delay(100);
                    }
                    else
                    {
                        cardPanelView.CardViews[i].sprite = _cardCollection.Cards[participantShuffleResult.Value[i]].CardView.BackSprite;
                        cardPanelView.CardViews[i].gameObject.SetActive(true);
                        // TODO make this visual config
                        await UniTask.Delay(50);
                    }
                }
            }

        }

        private CardPanelView GetCardPanelView(
            int currentParticipantIndex,
            int participantCout)
        {
            if (participantCout == 4)
            {
                return currentParticipantIndex switch
                {
                    0 => _cardPanelCollectionView.BottomCardPanel!,
                    1 => _cardPanelCollectionView.RightCardPanel!,
                    2 => _cardPanelCollectionView.TopCardPanel!,
                    3 => _cardPanelCollectionView.LeftCardPanel!,
                    _ => throw new InvalidOperationException("Invalid participant index"),
                };
            }
            else if (participantCout == 2)
            {
                return currentParticipantIndex switch
                {
                    0 => _cardPanelCollectionView.BottomCardPanel!,
                    1 => _cardPanelCollectionView.TopCardPanel!,
                    _ => throw new InvalidOperationException("Invalid participant index"),
                };
            }
            else
            {
                throw new InvalidOperationException("Number of participants are not supported");
            }
        }
    }
}
