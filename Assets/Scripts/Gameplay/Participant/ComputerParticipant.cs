using System;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class ComputerParticipant : BaseParticipant
    {
        public override ParticipantIdEnum Id => _id;

        private ParticipantIdEnum _id;

        public ComputerParticipant(
            ParticipantIdEnum participantIdEnum,
            string name,
            ICardCollection cardCollection) : base(name, cardCollection)
        {
            _id = participantIdEnum;

            // TODO also resolve computer ai logic here
        }

        public override void StartTurn(Action<ParticipantIdEnum> onDone)
        {
            // TODO delegate play to computer ai logic
            throw new NotImplementedException();
        }
    }
}
