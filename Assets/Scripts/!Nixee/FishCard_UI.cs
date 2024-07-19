using ShipMotorika;
using UnityEngine;
using UnityEngine.UI;
using static ShipMotorika.FishAlbum;

public class FishCard_UI : Singleton<FishCard_UI>
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject BackgroundBlack;
    [SerializeField] private Image FishIcon;
    [SerializeField] private Image BackgroundIcon;
    [SerializeField] private Text FishName;
    [SerializeField] private Text FishDesc;

    private void Start()
    {
        card.SetActive(false);
        BackgroundBlack.SetActive(false);
    }

    public void ToggleCard()
    {
        card.SetActive(!card.activeInHierarchy);
        BackgroundBlack.SetActive(card.activeInHierarchy);
    }

    public void UpdateCard(Card fish)
    {
        if (fish.WasOpened == false)
        {
            FishName.text = "???";
            FishDesc.text = "»нтересно, что же это за рыба?";
            FishIcon.sprite = fish.Asset.Sprite;
            FishIcon.color = Color.black;
            BackgroundIcon.color = new Color(114, 114, 114);
        }
        else
        {
            FishName.text = fish.Asset.Name;
            FishDesc.text = fish.Asset.Description;
            FishIcon.sprite = fish.Asset.Sprite;
            FishIcon.color = Color.white;
            BackgroundIcon.color = Color.white;
        }
    }
}
