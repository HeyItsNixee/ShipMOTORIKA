using UnityEngine;
using UnityEngine.UI;

public class HandSetting : Singleton<HandSetting>
{
    [SerializeField] private Sprite leftActive;
    [SerializeField] private Sprite leftInactive;
    [SerializeField] private Sprite rightActive;
    [SerializeField] private Sprite rightInactive;
    [Space]
    [SerializeField] private Image leftButton;
    [SerializeField] private Image rightButton;

    private bool isRightHanded = true;
    public bool IsRightHanded => isRightHanded;


    private void Start()
    {
        if (isRightHanded)
            SetRightHandedControls();
        else
            SetLeftHandedControls();
    }

    public void SetRightHandedControls()
    {
        leftButton.sprite = leftInactive;
        rightButton.sprite = rightActive;
    }
    public void SetLeftHandedControls()
    {
        leftButton.sprite = leftActive;
        rightButton.sprite = rightInactive;
    }
}
