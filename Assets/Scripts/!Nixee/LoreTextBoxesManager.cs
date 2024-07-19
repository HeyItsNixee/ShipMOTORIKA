using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoreTextBoxesManager : Singleton<LoreTextBoxesManager>
{
    [SerializeField] private GameObject[] BGs;
    [SerializeField] private LoreTextBox[] textBoxes;
    private int currentIndex = 0;


    private void Start()
    {
        if (textBoxes.Length < 1)
        {
            Debug.LogWarning("TextBoxes are empty in " + name);
            enabled = false;
        }

        for (int i = 0; i < textBoxes.Length; i++)
            textBoxes[i].gameObject.SetActive(false);

        textBoxes[currentIndex].gameObject.SetActive(true);
    }

    public void ShowNext()
    {
        textBoxes[currentIndex].gameObject.SetActive(false);
        currentIndex++;

        if (currentIndex >= textBoxes.Length)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            textBoxes[currentIndex].gameObject.SetActive(true);
    }

    public void CutsceneWatched()
    {
        StoryManager.Instance.OnQuestCompleted();
        transform.parent.gameObject.SetActive(false);
    }

    public void ChangeBG(int id)
    {
        if (id < 0 || id >= BGs.Length)
            return;

        foreach (var bg in BGs)
            bg.SetActive(false);

        BGs[id].SetActive(true);
    }

}
