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
        public Card[] Cards => _cards;

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
            var data = SceneDataHandler.Data.FishAlbum;

            foreach (var fishCard in data)
            {
                string[] values = fishCard.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < values.Length; i += 2)
                {
                    string fishName = values[i];
                    bool fishStatus = bool.Parse(values[i + 1]);

                    foreach (var card in _cards)
                    {
                        if (card.Asset.Name == fishName)
                        {
                            card.WasOpened = fishStatus;
                        }
                    }
                }
            }
        }

        public void Save()
        {
            SceneDataHandler.Data.FishAlbum = new string[_cards.Length];
            var data = SceneDataHandler.Data.FishAlbum;
            string[] fishNames = new string[_cards.Length];
            bool[] fishStatuses = new bool[_cards.Length];

            for (int i = 0; i < _cards.Length; i++)
            {
                fishNames[i] = _cards[i].Asset.Name;
                fishStatuses[i] = _cards[i].WasOpened;

                data[i] = $"{fishNames[i]}: {fishStatuses[i]}";
            }
        }
    }
}