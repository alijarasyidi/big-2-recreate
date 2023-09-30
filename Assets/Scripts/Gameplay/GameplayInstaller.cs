using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField]
        private CardCollectionScriptableObject? _cardCollectionData = null;

        public void Install(IContainerBuilder builder)
        {
            if (_cardCollectionData == null)
            {
                throw new InvalidOperationException("Card Collection Data is null! Make sure to provide the data correctly");
            }

            builder.RegisterInstance<ICardCollection>(_cardCollectionData);

            builder.RegisterEntryPoint<GameController>(Lifetime.Singleton);

            builder.Register<ParticipantResolver>(Lifetime.Singleton);

            builder.Register<CardShuffleService>(Lifetime.Singleton)
                .As<ICardShuffleService>();
        }
    }
}
