using System;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public abstract class BaseParticipant : IParticipant
    {
        public abstract ParticipantIdEnum Id { get; }
        public abstract ParticipantIdEnum NextId { get; }
        public string Name => _name;
        public int CardCount => _cardCount;

        protected string _name;
        protected int _cardCount = 0;
        protected List<Card> _handCard = new();

        protected readonly ICardCollection _cardCollection;

        public BaseParticipant(
            string name,
            ICardCollection cardCollection)
        {
            _name = name;
            _cardCollection = cardCollection;
        }

        public void SetInitialCardInHandIndex(List<int> initialCardInHandIndex)
        {
            _cardCount = initialCardInHandIndex.Count;
            foreach (var cardIndex in initialCardInHandIndex)
            {
                _handCard.Add(_cardCollection.Cards[cardIndex]);
            }
        }

        public abstract void StartTurn(Action<ParticipantIdEnum, ISubmittableCard> onDone);
    }
}
