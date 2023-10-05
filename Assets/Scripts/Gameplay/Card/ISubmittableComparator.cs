#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface ISubmittableComparator
    {
        bool IsValidSubmittable(
            ISubmittableCard tableSubmittableCard,
            ISubmittableCard toBeSubmittedCard);
    }
}
