using UnityEngine;
using UnityEngine.UI;

public class AvatarsPanel : MonoBehaviour
{
    [SerializeField] private AvatarButton[] avatarButtons;

    private void Start()
    {
        if (avatarButtons.Length <= 0 || AvatarManager.Instance.SmallAvatars.Length <= 0 
                                      || AvatarManager.Instance.SmallAvatars.Length != avatarButtons.Length)
        {
            Debug.Log("Links from editor have errors in object " + name);
            return;
        }

        for (int i = 0; i < avatarButtons.Length; i++)
        {
            avatarButtons[i].OnSelectAvatar += PlayerAssignPanel_UI.Instance.OnAvatarSelected;
            avatarButtons[i].SetAvatarSprite(AvatarManager.Instance.SmallAvatars[i]);
            avatarButtons[i].SetIndex(i);
        }

        avatarButtons[0].OnSelectAvatar?.Invoke(avatarButtons[0]);
    }

    

    private void OnDestroy()
    {
        foreach (var button in avatarButtons)
            button.OnSelectAvatar -= PlayerAssignPanel_UI.Instance.OnAvatarSelected;
    }
}
