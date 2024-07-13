using ShipMotorika;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_FishCollectionCard : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image FishIcon;
    [SerializeField] private Image BackgroundIcon;
    [SerializeField] private Button fishButton;

    private FishAsset asset;
    public void OnPointerClick(PointerEventData eventData)
    {
        FishCard_UI.Instance.UpdateCard(asset);
        FishCard_UI.Instance.ToggleCard();
    }

    private void Start()
    {
        if (Player.Instance)
            Player.Instance.FishingRod.OnFishAssigned += UpdateFishIcon;
    }


    private void OnDestroy()
    {
        if (Player.Instance)
            Player.Instance.FishingRod.OnFishAssigned += UpdateFishIcon;
    }

    public void SetAsset(FishAsset fishAsset)
    {
        if (fishAsset != null)
            asset = fishAsset;
    }

    public void UpdateFishIcon()
    {
        //Should check in save which kind of fish was caught before. Probably should save allFishVariations
        if (asset == null)
        {
            Debug.LogWarning("asset is null in " + name);
            enabled = false;
            return;
        }

        FishIcon.sprite = asset.Sprite;

        if (asset.wasCaughtOnce)
        {
            FishIcon.color = Color.white;
            BackgroundIcon.color = Color.white;
        }
        else
        {
            FishIcon.color = Color.black;
            BackgroundIcon.color = new Color(114, 114, 114);
        }
    }
}
