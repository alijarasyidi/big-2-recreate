using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class SubmittableCard : ISubmittableCard
    {
        public PokerHandEnum PokerHand => _pokerHand;
        public List<Card> Cards => _cards;

        private PokerHandEnum _pokerHand;
        private List<Card> _cards;

        public SubmittableCard(
            PokerHandEnum pokerHand,
            List<Card> cards)
        {
            _pokerHand = pokerHand;
            _cards = cards;
        }
    }
}
