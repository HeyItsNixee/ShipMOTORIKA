using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private Image avatarImg;

    private void OnEnable()
    {
        avatarImg.sprite = AvatarManager.Instance.SelectedAvatar;
        Debug.Log("HEH");
    }
}
