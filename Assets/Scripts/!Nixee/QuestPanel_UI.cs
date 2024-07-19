using UnityEngine;
using UnityEngine.UI;

public class QuestPanel_UI : MonoBehaviour
{
    [SerializeField] private Text questTitle;
    [SerializeField] private Text questDescription;

    private void Start()
    {
        if (StoryManager.Instance == null)
            enabled = false;
    }

    public void UpdateText()
    {
        questTitle.text = StoryManager.Instance.CurrentQuest.QuestName;
        questDescription.text = StoryManager.Instance.CurrentQuest.QuestDescription;
    }

    private void OnEnable()
    {
        UpdateText();
    }
}
