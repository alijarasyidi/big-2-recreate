using Alija.Big2.Client.Gameplay;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Screen
{
    public interface IParticipantView
    {
        void Setup(List<IParticipantInfo> participantInfos);
        void StartTurn(ParticipantIdEnum participantId);
        void EndGame(ParticipantIdEnum winnerParticipantId);
    }
}
