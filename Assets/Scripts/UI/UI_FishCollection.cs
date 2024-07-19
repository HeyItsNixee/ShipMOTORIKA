using ShipMotorika;
using UnityEngine;

public class UI_FishCollection : MonoBehaviour
{
    [SerializeField] private UI_FishCollectionCard UI_CardPrefab;

    private void Start()
    {
        if (FishAlbum.Instance == null)
            return;

        if (FishAlbum.Instance.Cards.Length <= 0 || UI_CardPrefab == null)
        {
            Debug.LogWarning("Nullref in " + name);
            enabled = false;
            return;
        }

        for (int i = 0; i < FishAlbum.Instance.Cards.Length; i++)
        {
            UI_FishCollectionCard card = Instantiate(UI_CardPrefab, transform);
            card.SetAsset(FishAlbum.Instance.Cards[i]);
            card.UpdateFishIcon();
        }
    }
}
