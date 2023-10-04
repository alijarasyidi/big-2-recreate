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

        public void Install(IContainerBuilder builder)
        {
            if (_cardPanelCollectionView == null)
            {
                throw new InvalidOperationException("Card Collection Panel View is null!");
            }

            builder.RegisterComponent<CardPanelCollectionView>(_cardPanelCollectionView);

            builder.Register<TableView>(Lifetime.Singleton)
                .As<ITableView>();
        }
    }
}
