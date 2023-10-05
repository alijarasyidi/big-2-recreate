using System;
using UnityEngine;
using UnityEngine.UI;

#nullable enable

namespace Alija.Big2.Client.Gameplay
{
    [Serializable]
    public class CardView
    {
        public bool IsRevealed;
        public Sprite? Sprite;
        public Sprite? BackSprite;
        public Image? CardVisualReference;
    }
}
