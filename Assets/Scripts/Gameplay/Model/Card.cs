using System;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    [Serializable]
    public class Card
    {
        public RankEnum Rank;
        public SuiteEnum Suite;
        public bool IsRevealed;
    }
}
