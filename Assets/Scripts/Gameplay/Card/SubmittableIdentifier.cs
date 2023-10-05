using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class SubmittableIdentifier : ISubmittableIdentifier
    {
        public bool TryGetSubmittable(
            List<Card> cards,
            out ISubmittableCard? submittableCard)
        {
            switch (cards.Count)
            {
                case 1:
                    submittableCard = new SubmittableCard(
                        PokerHandEnum.Single,
                        new List<Card>() { cards[0] });
                    return true;
                case 2:
                    if (cards[0].Rank == cards[1].Rank)
                    {
                        submittableCard = new SubmittableCard(
                            PokerHandEnum.Pair,
                            new List<Card>() { cards[0], cards[1] });
                        return true;
                    }
                    else
                    {
                        submittableCard = null;
                        return false;
                    }
                case 3:
                    if (cards[0].Rank == cards[1].Rank && cards[0].Rank == cards[2].Rank)
                    {
                        submittableCard = new SubmittableCard(
                            PokerHandEnum.ThreeOfAKind,
                            new List<Card>() { cards[0], cards[1], cards[2] });
                        return true;
                    }
                    else
                    {
                        submittableCard = null;
                        return false;
                    }
                case 5:
                // TODO support 5 poker hand
                default:
                    submittableCard = null;
                    return false;
            }
        }
    }
}
