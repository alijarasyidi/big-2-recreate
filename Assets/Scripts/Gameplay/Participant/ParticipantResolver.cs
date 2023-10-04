using System;
using System.Collections.Generic;
using Alija.Big2.Client.AI;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class ParticipantResolver
    {
        private readonly ICardCollection _cardCollection;
        private readonly ITableInfo _tableInfo;
        private readonly IComputeSubmittable _computeSubmittable;

        public ParticipantResolver(
            ICardCollection cardCollection,
            ITableInfo tableInfo,
            IComputeSubmittable computeSubmittable)
        {
            _cardCollection = cardCollection;
            _tableInfo = tableInfo;
            _computeSubmittable = computeSubmittable;
        }

        public List<IParticipant> ResolveParticipants(GameModeEnum gameMode)
        {
            switch (gameMode)
            {
                case GameModeEnum.PvCom4:
                    var participants = new List<IParticipant>()
                    {
                        // new PlayerParticipant(
                        //     "Player",
                        //     ParticipantIdEnum.OpponentOne,
                        //     _cardCollection),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentFour,
                            "Com0",
                            ParticipantIdEnum.OpponentOne,
                            _cardCollection,
                            _tableInfo,
                            _computeSubmittable),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentOne,
                            "Com1",
                            ParticipantIdEnum.OpponentTwo,
                            _cardCollection,
                            _tableInfo,
                            _computeSubmittable),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentTwo,
                            "Com2",
                            ParticipantIdEnum.OpponentThree,
                            _cardCollection,
                            _tableInfo,
                            _computeSubmittable),
                        new ComputerParticipant(
                            ParticipantIdEnum.OpponentThree,
                            "Com3",
                            ParticipantIdEnum.OpponentFour,
                            _cardCollection,
                            _tableInfo,
                            _computeSubmittable)
                    };
                    return participants;
                default:
                    throw new InvalidOperationException("Invalid game mode!");
            }
        }
    }
}
