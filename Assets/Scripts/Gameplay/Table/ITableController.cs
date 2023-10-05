using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface ITableController
    {
        void Setup(List<IParticipantInfo> participants);
        void SubmitCard(
            ParticipantIdEnum participantId,
            ISubmittableCard submittedCard);
        void Clear();
    }
}
