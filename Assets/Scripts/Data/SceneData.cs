using System;
using UnityEngine;

namespace ShipMotorika
{
    [Serializable]
    public class SceneData
    {
        public sealed class TransformData
        {
            public Vector3 Position;
            public Quaternion Rotation;
            public Vector3 Scale;
        }
        
        public int Health;
        public int Money;
        public int FishCost;
        public int FishWeight;
        public string PathToShipAsset;
        public string PathToFishingRodAsset;

        public TransformData ShipPosition;
        public TransformData RestorePointPosition;

        public ShipAsset ShipAsset;
        public FishingRodAsset FishingRodAsset;
    }
}