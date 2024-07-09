using UnityEngine;
using UnityEngine.UI;

public class LoreTextBox : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private float writeSpeed;

    private string bufferedString;
    private int currentChar = 0;
    private float timer = 0f;

    private void Start()
    {
        bufferedString = text.text;
        text.text = "";
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
            return;

        text.text += bufferedString[currentChar];
        currentChar++;
        timer = 0f;
    }
}
