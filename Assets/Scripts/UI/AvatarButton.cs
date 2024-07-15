using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AvatarButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image avatarSprite;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite activeBackgroundSprite;
    [SerializeField] private Sprite defaultBackgroundSprite;
    private int indexInPanel = -1;
    public void SetIndex(int value) { indexInPanel = value; }
    public Image AvatarSprite => avatarSprite;
    public int IndexInPanel => indexInPanel;

    public Action<AvatarButton> OnSelectAvatar;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (indexInPanel < 0)
            return;

        OnSelectAvatar?.Invoke(this);
    }

    public void SetAvatarSprite(Sprite newSprite)
    {
        if (newSprite == null)
        {
            Debug.Log("newSprite is null in " + name);
            return;
        }

        avatarSprite.sprite = newSprite;
    }

    public void SetActiveBG()
    {
        backgroundImage.sprite = activeBackgroundSprite;
    }

    public void SetDefaultBG()
    {
        backgroundImage.sprite = defaultBackgroundSprite;
    }
}

