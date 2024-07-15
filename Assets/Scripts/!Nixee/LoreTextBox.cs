using UnityEngine;
using UnityEngine.UI;

public class LoreTextBox : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;
    [SerializeField] private float writeSpeed;
    [SerializeField] private bool isChangingBG;
    [SerializeField] private int BG_ID;

    private string bufferedString;
    private int currentChar = 0;
    private float timer = 0f;

    private void Start()
    {
        bufferedString = text.text;
        text.text = "";
        UI_ArrowForTextBoxes.Instance.EnableArrow(false);
        button.enabled = false;

        if (isChangingBG)
        {
            LoreTextBoxesManager.Instance.ChangeBG(BG_ID);
        }
    }

    private void Update()
    {
        if (timer >= writeSpeed)
            WriteChar();
        else
            timer += Time.deltaTime;
    }

    private void WriteChar()
    {
        if (currentChar >= bufferedString.Length)
        {
            UI_ArrowForTextBoxes.Instance.EnableArrow(true);
            button.enabled = true;
            return;
        }

        text.text += bufferedString[currentChar];
        currentChar++;
        timer = 0f;
    }
}
