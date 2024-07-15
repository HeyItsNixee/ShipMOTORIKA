using UnityEngine;
using UnityEngine.UI;

public class UI_ArrowForTextBoxes : Singleton<UI_ArrowForTextBoxes>
{
    [SerializeField] private Image arrowImage;

    public void EnableArrow(bool state)
    {
        arrowImage.enabled = state;
    }

}
