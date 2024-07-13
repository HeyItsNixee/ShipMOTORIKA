using UnityEngine;

public class PauseList : MonoBehaviour
{
    [SerializeField] private GameObject List;
    [SerializeField] private GameObject DarkBG;


    public void ToggleList()
    {
        List.SetActive(!List.activeInHierarchy);
        DarkBG.SetActive(List.activeInHierarchy);
    }
}
