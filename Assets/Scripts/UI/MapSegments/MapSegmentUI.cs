using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MapSegmentUI : MonoBehaviour
{
    [SerializeField] private Animator cloudsAnimator;
    [SerializeField] private GameObject cloudsObj;
    private bool isSegmentRevealed = false;


    public void RevealSegment()
    {
        isSegmentRevealed = true;
        StartCoroutine(RevealClouds(1f));
    }

    private IEnumerator RevealClouds(float seconds)
    {
        cloudsAnimator.enabled = true;
        yield return new WaitForSeconds(seconds);
        cloudsAnimator.enabled = false;
        cloudsObj.SetActive(!isSegmentRevealed);
    }
}
