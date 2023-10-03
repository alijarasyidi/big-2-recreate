using System;
using System.Linq;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class SubmittableComparator : ISubmittableComparator
    {
        public bool IsValidSubmittable(
            ISubmittableCard tableSubmittableCard,
            ISubmittableCard toBeSubmittedCard)
        {

            if (tableSubmittableCard.PokerHand == PokerHandEnum.None || toBeSubmittedCard.PokerHand == PokerHandEnum.None)
            {
                throw new InvalidOperationException("Cannot compare PokerHand.None");
            }

            switch (tableSubmittableCard.PokerHand)
            {
                case PokerHandEnum.Single:
                    if (toBeSubmittedCard.PokerHand != PokerHandEnum.Single)
                    {
                        return false;
                    }

                    return IsGreaterRankSuite(
                        toBeSubmittedCard.Cards[0],
                        tableSubmittableCard.Cards[0]);
                case PokerHandEnum.Pair:
                    if (toBeSubmittedCard.PokerHand != PokerHandEnum.Pair)
                    {
                        return false;
                    }

                    var tableCard = (int)tableSubmittableCard.Cards[0].Suite > (int)tableSubmittableCard.Cards[1].Suite ?
                        tableSubmittableCard.Cards[0] : tableSubmittableCard.Cards[1];

                    var submittedCard = (int)toBeSubmittedCard.Cards[0].Suite > (int)toBeSubmittedCard.Cards[1].Suite ?
                        toBeSubmittedCard.Cards[0] : toBeSubmittedCard.Cards[1];

                    return IsGreaterRankSuite(submittedCard, tableCard);
                case PokerHandEnum.ThreeOfAKind:
                    if (toBeSubmittedCard.PokerHand != PokerHandEnum.ThreeOfAKind)
                    {
                        return false;
                    }

                    return IsGreaterRank(
                        toBeSubmittedCard.Cards.First(),
                        tableSubmittableCard.Cards.First());
                default:
                    // TODO add support to "Straight" poker hand

                    // TODO add support to "Flush" poker hand

                    // TODO add support to "FullHouse" poker hand

                    // TODO add support to "FourOfAKind" poker hand

                    // TODO add support to "StraightFlush" poker hand

                    throw new InvalidOperationException("Invalid submittable card poker hand");
            }
        }

        private bool IsGreaterRankSuite(Card leftSideCard, Card rightSideCard)
        {
            if ((int)leftSideCard.Rank < (int)rightSideCard.Rank)
            {
                return false;
            }
            else if ((int)leftSideCard.Rank == (int)rightSideCard.Rank)
            {
                if ((int)leftSideCard.Suite > (int)rightSideCard.Suite)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool IsGreaterRank(Card leftSideCard, Card rightSideCard)
        {
            if ((int)leftSideCard.Rank <= (int)rightSideCard.Rank)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
