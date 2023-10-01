using System;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class ComputerParticipant : BaseParticipant
    {
        public override ParticipantIdEnum Id => _id;
        public override ParticipantIdEnum NextId => _nextId;

        private ParticipantIdEnum _id;
        private ParticipantIdEnum _nextId;

        public ComputerParticipant(
            ParticipantIdEnum participantId,
            string name,
            ParticipantIdEnum nextParticipantId,
            ICardCollection cardCollection) : base(name, cardCollection)
        {
            _id = participantId;
            _nextId = nextParticipantId;

            // TODO also resolve computer ai logic here
        }

        public override void StartTurn(Action<ParticipantIdEnum, ISubmittableCard> onDone)
        {
            // TODO delegate play to computer ai logic
            throw new NotImplementedException();
        }
    }
}
