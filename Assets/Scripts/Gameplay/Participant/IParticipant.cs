using System;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface IParticipant
    {
        ParticipantIdEnum Id { get; }
        ParticipantIdEnum NextId { get; }
        string Name { get; }
        int CardCount { get; }

        void SetInitialCardInHandIndex(List<int> initialCardInHandIndex);
        void StartTurn(Action<ParticipantIdEnum> onDone);
    }
}
