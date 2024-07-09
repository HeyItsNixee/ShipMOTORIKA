using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD_UI : Singleton<PlayerHUD_UI>
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mapPanel;

    private void Start()
    {
        if (pausePanel == null || settingsPanel == null || mapPanel == null)
        {
            Debug.LogWarning("There's no panels links in " + name);
            enabled = false;
            return;
        }

        ClosePanel();
    }

    public void OpenPausePanel()
    {
        pausePanel.gameObject.SetActive(true);
        settingsPanel.SetActive(false);
        mapPanel.gameObject.SetActive(false);
    }

    public void OpenSettingsPanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(true);
        mapPanel.gameObject.SetActive(false);
    }

    public void OpenMapPanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(false);
        mapPanel.gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(false);
        mapPanel.gameObject.SetActive(false);
    }
}
