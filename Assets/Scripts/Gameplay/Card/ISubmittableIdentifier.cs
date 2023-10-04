using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface ISubmittableIdentifier
    {
        bool TryGetSubmittable(
            List<Card> cards,
            out ISubmittableCard? submittableCard);
    }
}
