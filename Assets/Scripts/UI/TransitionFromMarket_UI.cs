using UnityEngine;

public class TransitionFromMarket_UI : MonoBehaviour
{
    [SerializeField] private GameObject transitionTarget;
    [SerializeField] private float waitTime;
    private float internalTimer = 0f;

    private void OnEnable()
    {
        internalTimer = 0f;
    }

    private void Update()
    {
        if (internalTimer >= waitTime)
        {
            transitionTarget.SetActive(true);
        }
        else
            internalTimer += Time.deltaTime;
    }
}
