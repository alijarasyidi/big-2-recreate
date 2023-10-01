#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public interface IParticipantInfo
    {
        ParticipantIdEnum Id { get; }
        ParticipantIdEnum NextId { get; }
        string Name { get; }
        int CardCount { get; }
    }
}
