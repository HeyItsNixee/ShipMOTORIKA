using UnityEngine;

public class UI_InputAndListTogglerForShop : MonoBehaviour
{
    private void OnEnable()
    {
        if (UI_ForwardInputController.Instance)
            UI_ForwardInputController.Instance.transform.parent.gameObject.SetActive(false);
        if (PauseList.Instance)
            PauseList.Instance.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (UI_ForwardInputController.Instance)
            UI_ForwardInputController.Instance.transform.parent.gameObject.SetActive(true);
        if (PauseList.Instance)
            PauseList.Instance.gameObject.SetActive(true);
    }
}
