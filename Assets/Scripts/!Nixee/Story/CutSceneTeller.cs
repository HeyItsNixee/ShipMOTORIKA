using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneTeller : MonoBehaviour
{
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

        currentIndex = 0;
        textBoxes[currentIndex].gameObject.SetActive(true);
    }

    public void ShowNextOverworld()
    {
        textBoxes[currentIndex].gameObject.SetActive(false);
        currentIndex++;

        if (currentIndex >= textBoxes.Length)
        {
            CutSceneManager.Instance.CutSceneWatched();
            UI_ArrowForTextBoxes.Instance.EnableArrow(false);
            currentIndex = 0;
        }
        else
            textBoxes[currentIndex].gameObject.SetActive(true);
    }

}
