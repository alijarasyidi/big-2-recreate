using System;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class ParticipantResolver
    {
        private readonly ICardCollection _cardCollection;

        public ParticipantResolver(ICardCollection cardCollection)
        {
            _cardCollection = cardCollection;
        }

        public List<IParticipant> ResolveParticipants(GameModeEnum gameMode)
        {
            switch (gameMode)
            {
                case GameModeEnum.PvCom4:
                    var participants = new List<IParticipant>()
                    {
                        new PlayerParticipant(
                            "Player",
                            ParticipantIdEnum.OpponentOne,
                            _cardCollection),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentOne,
                            "Com1",
                            ParticipantIdEnum.OpponentTwo,
                            _cardCollection),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentTwo,
                            "Com2",
                            ParticipantIdEnum.OpponentThree,
                            _cardCollection),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentThree,
                            "Com3",
                            ParticipantIdEnum.Player,
                            _cardCollection)
                    };
                    return participants;
                default:
                    throw new InvalidOperationException("Invalid game mode!");
            }
        }
    }
}
