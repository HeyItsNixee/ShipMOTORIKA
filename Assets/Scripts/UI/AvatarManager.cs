using ShipMotorika;
using UnityEngine;

public class AvatarManager : SingletonBase<AvatarManager>
{
    [SerializeField] private Sprite[] smallAvatars;
    public Sprite[] SmallAvatars => smallAvatars;

    public Sprite SelectedAvatar => smallAvatars[PlayerSettingsHolder.Instance.settings.avatarSpriteIndex];
}
