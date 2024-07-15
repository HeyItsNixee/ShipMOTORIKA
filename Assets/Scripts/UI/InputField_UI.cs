using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputField_UI : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Text placeHolder;
    [SerializeField] private Text inputText;
    [SerializeField] private Button playButton;

    public void OnDeselect(BaseEventData eventData)
    {
        Submit();
    }

    public void OnSelect(BaseEventData eventData)
    {
        placeHolder.text = "";
    }

    public void Submit()
    {
        if (inputText.text == "" || inputText.text == " ")
        {
            placeHolder.text = "¬¿ÿ≈ »Ãﬂ";
            playButton.interactable = false;
            return;
        }

        playButton.interactable = true;
        //Save(InputField_UI.inputText);
    }
}
