using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private Image avatarImg;

    private void OnEnable()
    {
        if (AvatarManager.Instance)
            avatarImg.sprite = AvatarManager.Instance.SelectedAvatar;
    }
}
