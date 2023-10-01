#nullable enable

using System.Collections.Generic;

namespace Alija.Big2.Client.Gameplay
{
    public interface ITableInfo
    {
        ISubmittableCard? CurrentSubmittableCard { get; }
        bool IsFirstRound { get; }
        bool IsFirstTurn { get; }
        int SubmittedCardCount { get; }
        Dictionary<ParticipantIdEnum, IParticipantInfo> ParticipantInfoHasMap { get; }
    }
}
