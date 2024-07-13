using ShipMotorika;
using UnityEngine;

public class FishCollectionManager : Singleton<FishCollectionManager>
{
    [SerializeField] private FishAsset[] allFishVariations;
    public FishAsset[] AllFishAssets => allFishVariations;

    private void Start()
    {
        if (Player.Instance)
            Player.Instance.FishingRod.OnFishAssigned += OnFirstCaught;
    }


    private void OnFirstCaught()
    {
        Player.Instance.FishingRod.CaughtFish.fishAsset.wasCaughtOnce = true;
    }

    private void OnDestroy()
    {
        if (Player.Instance)
            Player.Instance.FishingRod.OnFishAssigned -= OnFirstCaught;
    }
}
