using ShipMotorika;
using UnityEngine;
using UnityEngine.UI;

public class SettingCheckbox : MonoBehaviour
{
    [SerializeField] private Image imageComponent;
    [SerializeField] private Sprite checkBoxTrue;
    [SerializeField] private Sprite checkBoxFalse;

    private void Start()
    {
        UpdateSprite();
    }

    private void OnEnable()
    {
        UpdateSprite();
    }

    public void Toggle()
    {
        PlayerSettingsHolder.Instance.SetSideControlButtonsEnabled(!PlayerSettingsHolder.Instance.settings.sideControlButtonsEnabled);
        UpdateSprite();
        Debug.Log("Toggle called in " + name);
    }

    public void UpdateSprite()
    {
        if (PlayerSettingsHolder.Instance.settings.sideControlButtonsEnabled)
            imageComponent.sprite = checkBoxTrue;
        else
            imageComponent.sprite = checkBoxFalse;
    }
}
