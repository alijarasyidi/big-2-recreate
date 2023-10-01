using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface ISubmittableCard
    {
        PokerHandEnum PokerHand { get; }
        List<Card> Cards { get; }
    }
}
