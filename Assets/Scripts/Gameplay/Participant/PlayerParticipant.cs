using System;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class PlayerParticipant : BaseParticipant
    {
        public override ParticipantIdEnum Id => ParticipantIdEnum.Player;

        public PlayerParticipant(
            string name,
            ICardCollection cardCollection) : base(name, cardCollection)
        {
        }

        public override void StartTurn(Action<ParticipantIdEnum> onDone)
        {
            // TODO need to implement player input service
            throw new NotImplementedException();
        }
    }
}
