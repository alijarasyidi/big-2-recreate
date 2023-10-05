using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class SubmittableCombinationService : ISubmittableCombinationService
    {
        private Dictionary<RankEnum, List<Card>> _sameRankCountHashMap = new();
        private Dictionary<SuiteEnum, List<Card>> _sameSuiteCountHashMap = new();

        public void GetCombination(
            List<Card> cards,
            List<ISubmittableCard> submittables)
        {
            _sameRankCountHashMap.Clear();
            _sameSuiteCountHashMap.Clear();

            foreach (var card in cards)
            {
                // Get "Single" combination
                submittables.Add(new SubmittableCard(
                    PokerHandEnum.Single,
                    new List<Card>() { card }));

                if (!_sameRankCountHashMap.ContainsKey(card.Rank))
                {
                    _sameRankCountHashMap.Add(card.Rank, new List<Card>() { card });
                }
                else
                {
                    _sameRankCountHashMap[card.Rank].Add(card);
                }

                if (!_sameSuiteCountHashMap.ContainsKey(card.Suite))
                {
                    _sameSuiteCountHashMap.Add(card.Suite, new List<Card>() { card });
                }
                else
                {
                    _sameSuiteCountHashMap[card.Suite].Add(card);
                }
            }

            foreach (var sameRankCard in _sameRankCountHashMap)
            {
                if (sameRankCard.Value != null)
                {
                    // Get "Pair" combination
                    if (sameRankCard.Value.Count == 2)
                    {
                        submittables.Add(new SubmittableCard(
                            PokerHandEnum.Pair,
                            sameRankCard.Value));
                    }
                    else if (sameRankCard.Value.Count == 3) // Get "ThreeOfAKind" combination
                    {
                        submittables.Add(new SubmittableCard(
                            PokerHandEnum.ThreeOfAKind,
                            sameRankCard.Value));
                    }
                }
            }

            // TODO add support to "Straight" poker hand combination

            // TODO add support to "Flush" poker hand combination

            // TODO add support to "FullHouse" poker hand combination

            // TODO add support to "FourOfAKind" poker hand combination

            // TODO add support to "StraightFlush" poker hand combination
        }
    }
}
