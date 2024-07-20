using UnityEngine;

public class PauseList : Singleton<PauseList>
{
    [SerializeField] private GameObject bg;
    [SerializeField] private GameObject visual;
    [SerializeField] private GameObject List;


    public void ToggleList()
    {
        visual.SetActive(!visual.activeInHierarchy);
        bg.SetActive(!visual.activeInHierarchy);
        List.SetActive(!List.activeInHierarchy);
    }
}
