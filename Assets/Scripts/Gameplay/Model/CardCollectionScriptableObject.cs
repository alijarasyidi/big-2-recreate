using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    [CreateAssetMenu(fileName = "CardCollectionData")]
    public class CardCollectionScriptableObject : ScriptableObject
    {
        [SerializeField]
        private List<Card> _cards = new List<Card>();
    }
}
