using UnityEngine;
using UnityEngine.UI;


namespace ShipMotorika {
    public class TutorialInputHandler : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private InputType input;
        [SerializeField] private float secondsAmount = 1;
        private float timer = 0f;

        private void Start()
        {
            PlayerController.Instance.EnableControl();
        }

        private void Update()
        {
            if (timer >= secondsAmount)
                TutorialManager.Instance.ShowNext();

            if (input == PlayerController.Instance.CurrentInput)
            {
                background.enabled = false;
                timer += Time.deltaTime;
            }
            else
            {
                background.enabled = true;
                PlayerController.Instance.Stop();
            }
        }
    }
}