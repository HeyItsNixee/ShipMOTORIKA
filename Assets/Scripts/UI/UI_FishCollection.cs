using ShipMotorika;
using UnityEngine;

public class UI_FishCollection : MonoBehaviour
{
    [SerializeField] private UI_FishCollectionCard UI_CardPrefab;

    private void Start()
    {
        if (FishCollectionManager.Instance == null)
            return;

        if (FishCollectionManager.Instance.AllFishAssets.Length <= 0 || UI_CardPrefab == null)
        {
            Debug.LogWarning("Nullref in " + name);
            enabled = false;
            return;
        }

        for (int i = 0; i < FishCollectionManager.Instance.AllFishAssets.Length; i++)
        {
            UI_FishCollectionCard card = Instantiate(UI_CardPrefab, transform);
            card.SetAsset(FishCollectionManager.Instance.AllFishAssets[i]);
            card.UpdateFishIcon();
        }
    }
}
