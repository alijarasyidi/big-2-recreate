using System;
using System.Collections.Generic;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class GameModeResolver
    {
        private readonly ICardCollection _cardCollection;

        public GameModeResolver(ICardCollection cardCollection)
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
                            _cardCollection),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentOne,
                            "Com1",
                            _cardCollection),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentTwo,
                            "Com2",
                            _cardCollection),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentThree,
                            "Com3",
                            _cardCollection)
                    };
                    return participants;
                default:
                    throw new InvalidOperationException("Invalid game mode!");
            }
        }
    }
}
