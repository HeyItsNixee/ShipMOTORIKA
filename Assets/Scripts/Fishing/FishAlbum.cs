using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Содержит информацию о пойманных игроком рыбах.
    /// </summary>
    public sealed class FishAlbum : SingletonBase<FishAlbum>, ILoader, ISaver
    {
        [Serializable]
        public sealed class Card
        {
            public FishAsset Asset;
            public bool WasOpened;
        }

        [SerializeField] private Card[] _cards;

        public event Action OnFirstCatch;

        private new void Awake()
        {
            base.Awake();

            SceneDataHandler.Loaders.Add(this);
            SceneDataHandler.Savers.Add(this);
        }

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

        public void Load()
        {
            if (SceneDataHandler.Instance.HasSave())
            {
                var savedCards = SceneDataHandler.Data.FishCards;

                for (int i = 0; i < _cards.Length; i++)
                {
                    _cards[i].WasOpened = savedCards[i];
                }
            }          
        }

        public void Save()
        {            
            SceneDataHandler.Data.FishCards = new bool[_cards.Length];

            var savedCards = SceneDataHandler.Data.FishCards;

            for (int i = 0; i < savedCards.Length; i++)
            {
                savedCards[i] = _cards[i].WasOpened;
            }
        }
    }
}