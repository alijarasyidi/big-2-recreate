using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

#nullable enable

namespace Alija.Big2.Client.Screen
{
    public class ScreenInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField]
        private CardPanelCollectionView? _cardPanelCollectionView = null;

        [SerializeField]
        private ParticipantPanelCollectionView? _participantCollectionView = null;

        public void Install(IContainerBuilder builder)
        {
            if (_cardPanelCollectionView == null)
            {
                throw new InvalidOperationException("Card Collection Panel View is null!");
            }

            if (_participantCollectionView == null)
            {
                throw new InvalidOperationException("Participant Collection Panel View is null!");
            }

            builder.RegisterComponent<CardPanelCollectionView>(_cardPanelCollectionView);

            builder.RegisterComponent<ParticipantPanelCollectionView>(_participantCollectionView);

            builder.Register<TableView>(Lifetime.Singleton)
                .As<ITableView>();

            builder.Register<ParticipantView>(Lifetime.Singleton)
                .As<IParticipantView>();
        }
    }
}
