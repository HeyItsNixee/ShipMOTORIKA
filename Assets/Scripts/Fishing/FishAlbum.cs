using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Содержит информацию о пойманных игроком рыбах.
    /// </summary>
    public sealed class FishAlbum : SingletonBase<FishAlbum>
    {
        [Serializable]
        private sealed class Card
        {
            public FishAsset Asset;
            public bool WasOpened;
        }

        [SerializeField] private Card[] _cards;

        public event Action OnFirstCatch;

        public void CheckCardInfo()
        {
            if (_cards.Length > 0)
            {
                foreach (var card in _cards)
                {
                    var fish = Player.Instance.FishingRod.CaughtFish;
                    
                    if ((fish.Name == card.Asset.Name) && !card.WasOpened)
                    {
                        card.WasOpened = true;

                        OnFirstCatch?.Invoke();
                    }
                }
            }
        }
    }
}