using ShipMotorika;
using UnityEngine;
using UnityEngine.UI;

public class SettingCheckbox : MonoBehaviour
{
    [SerializeField] private Image imageComponent;
    [SerializeField] private Sprite checkBoxTrue;
    [SerializeField] private Sprite checkBoxFalse;
    private bool isChecked = false;

    private void Start()
    {
        UpdateSprite();
    }

    public void Toggle()
    {
        isChecked = !isChecked;
        UpdateSprite();
        PlayerSettingsHolder.Instance.SetSideControlButtonsEnabled(isChecked);
        Debug.Log("Toggle called in " + name);
    }

    private void UpdateSprite()
    {
        if (isChecked)
            imageComponent.sprite = checkBoxTrue;
        else
            imageComponent.sprite = checkBoxFalse;
    }
}
