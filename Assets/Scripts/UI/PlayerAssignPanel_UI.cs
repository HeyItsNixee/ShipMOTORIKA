using UnityEngine;
using UnityEngine.UI;

public class PlayerAssignPanel_UI : Singleton<PlayerAssignPanel_UI>
{
    [SerializeField] private Sprite[] avatarsBigSprites;
    [SerializeField] private Image playerSelectedAvatar;

    private AvatarButton lastSelectedButton;

    public void OnAvatarSelected(AvatarButton button)
    {
        if (button.IndexInPanel < 0 || button.IndexInPanel >= avatarsBigSprites.Length)
        {
            Debug.LogWarning("Button " + button.name + " have invalid index for " + name);
            return;
        }

        if (lastSelectedButton == button)
            return;
        playerSelectedAvatar.sprite = avatarsBigSprites[button.IndexInPanel];
        button.SetActiveBG();

        if (lastSelectedButton != null)
            lastSelectedButton.SetDefaultBG();

        lastSelectedButton = button;
    }

    public void Confirm()
    {
        Debug.Log("This should save nickname and avatar_ID");
    }
}
