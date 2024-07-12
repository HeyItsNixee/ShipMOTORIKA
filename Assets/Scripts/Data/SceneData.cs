using System;
using UnityEngine;

namespace ShipMotorika
{
    [Serializable]
    public sealed class SceneData
    {
        public Vector3 ShipPosition;
        public Quaternion ShipRotation;
        public Vector3 ShipScale;

        public Vector3 RestorePosition;
        public Quaternion RestoreRotation;
        public Vector3 RestoreScale;

        public int Health;
        public int Money;
        public int FishCost;
        public int FishWeight;

        public string ShipAssetName;
        public bool BronzeShipIsAvailable = true;
        public bool SilverShipIsAvailable = true;
        public bool GoldShipIsAvailable = true;

        public string FishingRodAssetName;
        public bool BronzeFishingRodIsAvailable = true;
        public bool SilverFishingRodIsAvailable = true;
        public bool GoldFishingRodIsAvailable = true;

        public string [] FishAlbum;
    }
}