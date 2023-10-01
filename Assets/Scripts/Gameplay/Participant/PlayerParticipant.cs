using System;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class PlayerParticipant : BaseParticipant
    {
        public override ParticipantIdEnum Id => ParticipantIdEnum.Player;
        public override ParticipantIdEnum NextId => _nextId;

        private ParticipantIdEnum _nextId;

        public PlayerParticipant(
            string name,
            ParticipantIdEnum nextParticipantId,
            ICardCollection cardCollection) : base(name, cardCollection)
        {
            _nextId = nextParticipantId;
        }

        public override void StartTurn(Action<ParticipantIdEnum, ISubmittableCard> onDone)
        {
            // TODO need to implement player input service
            throw new NotImplementedException();
        }
    }
}
