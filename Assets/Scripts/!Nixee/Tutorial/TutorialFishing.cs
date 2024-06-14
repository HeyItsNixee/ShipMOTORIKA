using ShipMotorika;
using UnityEngine;

public class TutorialFishing : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject successScreen;
    [SerializeField] private GameObject failureScreen;

    [SerializeField] private FishingChallenge fishingChallenge;
    [SerializeField] private GameObject fishingObject;
    [SerializeField] private float spawnOffset;

    private void Start()
    {
        tutorialScreen.SetActive(true);
        successScreen.SetActive(false);
        failureScreen.SetActive(false);

        fishingChallenge.gameObject.SetActive(true);

        fishingChallenge.OnTryCatchFish += OnFishCatch;

        fishingObject.transform.position = new Vector2(fishingObject.transform.position.x - spawnOffset,
                                                fishingObject.transform.position.y + spawnOffset);
        fishingObject.gameObject.SetActive(true);

        PlayerController.Instance.EnableControl();
    }

    private void OnFishCatch(bool value)
    {
        tutorialScreen.SetActive(false);
        if (value)
        {
            successScreen.SetActive(true);
            failureScreen.SetActive(false);
        }
        else
        {
            successScreen.SetActive(false);
            failureScreen.SetActive(true);
        }
    }
}
