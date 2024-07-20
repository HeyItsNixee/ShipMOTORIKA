using ShipMotorika;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD_UI : Singleton<PlayerHUD_UI>
{
    [SerializeField] private GameObject InputCanvas;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject collectionPanel;
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private GameObject questPanel;

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
        collectionPanel.gameObject.SetActive(false);
        mapPanel.gameObject.SetActive(false);
        questPanel.gameObject.SetActive(false);
        InputCanvas.SetActive(false);
    }

    public void OpenSettingsPanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(true);
        collectionPanel.gameObject.SetActive(false);
        mapPanel.gameObject.SetActive(false);
        questPanel.gameObject.SetActive(false);
        InputCanvas.SetActive(false);
    }

    public void OpenMapPanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(false);
        collectionPanel.gameObject.SetActive(false);
        mapPanel.gameObject.SetActive(true);
        questPanel.gameObject.SetActive(false);
        InputCanvas.SetActive(false);
    }

    public void OpenCollectionPanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(false);
        collectionPanel.gameObject.SetActive(true);
        mapPanel.gameObject.SetActive(false);
        questPanel.gameObject.SetActive(false);
        InputCanvas.SetActive(false);
    }

    public void OpenQuestPanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(false);
        collectionPanel.gameObject.SetActive(false);
        mapPanel.gameObject.SetActive(false);
        questPanel.gameObject.SetActive(true);
        InputCanvas.SetActive(false);
    }

    public void ClosePanel()
    {
        pausePanel.gameObject.SetActive(false);
        settingsPanel.SetActive(false);
        collectionPanel.gameObject.SetActive(false);
        mapPanel.gameObject.SetActive(false);
        questPanel.gameObject.SetActive(false);
        InputCanvas.SetActive(true);
    }

    public void DisableInput()
    {
        InputCanvas.SetActive(false);
    }

    public void EnableInput()
    {
        InputCanvas.SetActive(true);
    }
}
