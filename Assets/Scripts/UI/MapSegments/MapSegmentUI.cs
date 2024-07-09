using UnityEngine;
using UnityEngine.UI;

public class MapSegmentUI : MonoBehaviour
{
    [SerializeField] private GameObject cloudsObj;
    public bool isSegmentRevealed = false;


    public void RevealSegment()
    {
        isSegmentRevealed = true;
        cloudsObj.SetActive(!isSegmentRevealed);
    }


    //Debug
    private void Update()
    {
        cloudsObj.SetActive(!isSegmentRevealed);
    }
}
