using ShipMotorika;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAssignPanel_UI : Singleton<PlayerAssignPanel_UI>
{
    [SerializeField] private Sprite[] avatarsBigSprites;
    [SerializeField] private Image playerSelectedAvatar;

    private AvatarButton lastSelectedButton;
    private string playerName;

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
        PlayerSettingsHolder.Instance.settings.playerName = playerName;
        PlayerSettingsHolder.Instance.settings.avatarSpriteIndex = lastSelectedButton.IndexInPanel;

        if (FileHandler.HasFile("World_Scene.json"))
        {
            FileHandler.Reset("World_Scene.json");
            PlayerSettingsHolder.Instance.settings.questID = 0;
        }

        PlayerSettingsHolder.Instance.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetPlayerName(string new_name)
    {
        playerName = new_name;
    }
}
