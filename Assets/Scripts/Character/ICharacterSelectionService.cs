using Cysharp.Threading.Tasks;
using System.Threading;

#nullable enable

namespace Alija.Big2.Client.Character
{
    public interface ICharacterSelectionService
    {
        CharacterView GetSelectedCharacter();
        CharacterView GetComputerCharacter();

        UniTask ShowSelectCharacterAsync(CancellationToken cancellationToken);
    }
}
