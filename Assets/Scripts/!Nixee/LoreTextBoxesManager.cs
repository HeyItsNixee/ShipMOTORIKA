using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreTextBoxesManager : MonoBehaviour
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

}
