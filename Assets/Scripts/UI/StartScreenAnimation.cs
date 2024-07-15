using UnityEngine;

public class StartScreenAnimation : MonoBehaviour
{
    [SerializeField] private Animator bgAnimator;
    [SerializeField] private AnimationClip bgAnimation;
    [SerializeField] private GameObject mainMenuObj;

    private float timer = 0f;
    private float animationLength = 0f;


    private void Start()
    {
        ShowMainMenu(false);
        animationLength = bgAnimation.length;
    }

    private void Update()
    {
        if (timer >= animationLength)
        {
            ShowMainMenu(true);
            enabled = false;
        }
        else
            timer += Time.deltaTime;
    }

    private void ShowMainMenu(bool state)
    {
        mainMenuObj.SetActive(state);
        bgAnimator.enabled = !state;
    }
}
