using System;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface IParticipant : IParticipantInfo
    {
        void SetInitialCardInHandIndex(List<int> initialCardInHandIndex);
        void StartTurn(Action<ParticipantIdEnum, ISubmittableCard> onDone);
    }
}
