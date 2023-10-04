using System;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface ITableEventListener
    {
        event Action<List<IParticipantInfo>> OnTableSetup;
        event Action<ParticipantIdEnum, ISubmittableCard> OnCardSubmitted;
        event Action OnRoundEnded;
        event Action OnTableCleared;
    }
}
