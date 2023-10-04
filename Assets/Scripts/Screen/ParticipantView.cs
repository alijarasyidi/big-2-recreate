using Alija.Big2.Client.Gameplay;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable enable

namespace Alija.Big2.Client.Screen
{
    public class ParticipantView : IParticipantView
    {
        private Dictionary<ParticipantIdEnum, ParticipantPanelView> _participantPanelHashMap = new();

        private readonly ParticipantPanelCollectionView _participantCollectionView;
        private readonly ITableEventListener _tableEventListener;
        private readonly ITableInfo _tableInfo;

        public ParticipantView(
            ParticipantPanelCollectionView participantPanelCollectionView,
            ITableEventListener tableEventListener,
            ITableInfo tableInfo)
        {
            _participantCollectionView = participantPanelCollectionView;
            _tableEventListener = tableEventListener;
            _tableInfo = tableInfo;

            RegisterEventCallback();
        }

        private void RegisterEventCallback()
        {
            _tableEventListener.OnCardSubmitted += OnCardSubmitted;
        }

        private void OnCardSubmitted(
            ParticipantIdEnum participantId,
            ISubmittableCard submittableCard)
        {
            var participantPanel = _participantPanelHashMap[participantId];

            var cardCount = _tableInfo.ParticipantInfoHasMap[participantId].CardCount;

            participantPanel.CardCountText!.text = cardCount.ToString();
        }

        public void Setup(List<IParticipantInfo> participantInfos)
        {
            _participantPanelHashMap.Clear();
            for (int i = 0; i < participantInfos.Count; i++)
            {
                var participantView = GetParticipantPanelView(
                    i,
                    participantInfos.Count);

                participantView.NameText!.text = participantInfos[i].Name;
                participantView.CardCountText!.text = participantInfos[i].CardCount.ToString();
                participantView.CharacterImage!.color = new Color(0f, 0f, 0f, 0.5f);

                participantView.gameObject.SetActive(true);

                _participantPanelHashMap.Add(
                    participantInfos[i].Id,
                    participantView);
            }
        }

        public void StartTurn(ParticipantIdEnum participantId)
        {
            foreach (var participantPanel in _participantPanelHashMap.Values)
            {
                participantPanel.CharacterImage!.color = new Color(0f, 0f, 0f, 0.5f);
            }

            _participantPanelHashMap[participantId].CharacterImage!.color = new Color(1f, 1f, 1f, 1f);
        }

        private ParticipantPanelView GetParticipantPanelView(
            int currentParticipantIndex,
            int participantCount)
        {
            if (participantCount == 4)
            {
                return currentParticipantIndex switch
                {
                    0 => _participantCollectionView.BottomParticipantPanel!,
                    1 => _participantCollectionView.RightParticipantPanel!,
                    2 => _participantCollectionView.TopParticipantPanel!,
                    3 => _participantCollectionView.LeftParticipantPanel!,
                    _ => throw new InvalidOperationException("Invalid participant index"),
                };
            }
            else if (participantCount == 2)
            {
                return currentParticipantIndex switch
                {
                    0 => _participantCollectionView.BottomParticipantPanel!,
                    1 => _participantCollectionView.TopParticipantPanel!,
                    _ => throw new InvalidOperationException("Invalid participant index"),
                };
            }
            else
            {
                throw new InvalidOperationException("Number of participants are not supported");
            }
        }
    }
}
