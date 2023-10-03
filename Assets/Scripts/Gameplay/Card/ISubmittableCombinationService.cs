using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface ISubmittableCombinationService
    {
        void GetCombination(
            List<Card> cards,
            List<ISubmittableCard> submittables);
    }
}
