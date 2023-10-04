using System;
using System.Threading;
using Cysharp.Threading.Tasks;

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

        public override UniTask StartTurnAsync(
            Action<ParticipantIdEnum, ISubmittableCard> onDone,
            CancellationToken cancellationToken)
        {
            // TODO need to implement player input service
            throw new NotImplementedException();
        }
    }
}
