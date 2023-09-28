using Alija.Big2.Client.System;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class CardShuffleService : ICardShuffleService
    {
        private List<int> _mapIndex;

        private readonly ICardCollection _cardCollection;

        public CardShuffleService(ICardCollection cardCollection)
        {
            _cardCollection = cardCollection;

            _mapIndex = new List<int>();
            for (int i = 0; i < _cardCollection.Cards.Count; i++)
            {
                _mapIndex.Add(i);
            }
        }

        public Dictionary<int, List<int>> Shuffle(int playerCount)
        {
            _mapIndex.Shuffle();

            int cardsPerPlayer = _cardCollection.Cards.Count / playerCount;
            Dictionary<int, List<int>> playerShuffleResults = new();
            for (int i = 0; i < playerCount; i++)
            {
                List<int> shuffleResult = new();
                shuffleResult.AddRange(_mapIndex.GetRange(i * cardsPerPlayer, cardsPerPlayer));
                playerShuffleResults.Add(i, shuffleResult);
            }

            return playerShuffleResults;
        }
    }
}
